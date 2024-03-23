using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Logging;
using Google.Apis.Services;
using Google.Apis.Upload;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BillBook.Library
{
    class GDrive
    {
        #region Consts
        private const int KB = 0x400;
        private const int DownloadChunkSize = 256 * KB;

        // CHANGE THIS with full path to the file you want to upload
        private const string UploadFileName = @"FILE_TO_UPLOAD";

        // CHANGE THIS with a download directory
        private const string DownloadDirectoryName = @"DIRECTORY_FOR_DOWNLOADING";

        // CHANGE THIS if you upload a file type other than a jpg
        private const string ContentType = @"image/jpeg";
        #endregion

        /// <summary>The logger instance.</summary>
        private static readonly ILogger Logger;

        /// <summary>The Drive API scopes.</summary>
        private static readonly string[] Scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };

        /// <summary>
        /// The file which was uploaded. We will use its download Url to download it using our media downloader object.
        /// </summary>
        private static File uploadedFile;

        private async Task Run()
        {
            GoogleWebAuthorizationBroker.Folder = "Drive.Sample";
            UserCredential credential;

            using (var stream = new System.IO.FileStream("client_secrets.json",
                System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None);
            }

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API Sample",
            });

            await UploadFileAsync(service);

            // uploaded succeeded
            Console.WriteLine("\"{0}\" was uploaded successfully", uploadedFile.Title);
            await DownloadFile(service, uploadedFile.DownloadUrl);
            await DeleteFile(service, uploadedFile);
        }

        /// <summary>Uploads file asynchronously.</summary>
        private Task<IUploadProgress> UploadFileAsync(DriveService service)
        {
            var title = UploadFileName;
            if (title.LastIndexOf('\\') != -1)
            {
                title = title.Substring(title.LastIndexOf('\\') + 1);
            }

            var uploadStream = new System.IO.FileStream(UploadFileName, System.IO.FileMode.Open,
                System.IO.FileAccess.Read);

            var insert = service.Files.Insert(new File { Title = title }, uploadStream, ContentType);
            insert.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * 2;
            insert.ProgressChanged += Upload_ProgressChanged;
            insert.ResponseReceived += Upload_ResponseReceived;

            var task = insert.UploadAsync();
            task.ContinueWith(t =>
            {
                // NotOnRanToCompletion - this code will be called if the upload fails
                Console.WriteLine("Upload Failed. " + t.Exception);
            }, TaskContinuationOptions.NotOnRanToCompletion);

            task.ContinueWith(t =>
            {
                Logger.Debug("Closing the stream");
                uploadStream.Dispose();
                Logger.Debug("The stream was closed");
            });

            return task;
        }

        /// <summary>Downloads the media from the given URL.</summary>
        private async Task DownloadFile(DriveService service, string url)
        {
            var downloader = new MediaDownloader(service);
            downloader.ChunkSize = DownloadChunkSize;

            // add a delegate for the progress changed event for writing to console on changes
            downloader.ProgressChanged += Download_ProgressChanged;

            // figure out the right file type base on UploadFileName extension
            var lastDot = UploadFileName.LastIndexOf('.');
            var fileName = DownloadDirectoryName + @"\Download" +
                (lastDot != -1 ? "." + UploadFileName.Substring(lastDot + 1) : "");

            using (var fileStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var progress = await downloader.DownloadAsync(url, fileStream);

                if (progress.Status == DownloadStatus.Completed)
                {
                    Console.WriteLine(fileName + " was downloaded successfully");
                }
                else
                {
                    Console.WriteLine("Download {0} was interpreted in the middle. Only {1} were downloaded. ",
                        fileName, progress.BytesDownloaded);
                }
            }
        }

        /// <summary>Deletes the given file from drive (not the file system).</summary>
        private async Task DeleteFile(DriveService service, File file)
        {
            Console.WriteLine("Deleting file '{0}'...", file.Id);
            await service.Files.Delete(file.Id).ExecuteAsync();
            Console.WriteLine("File was deleted successfully");
        }

        #region Progress and Response changes
        static void Download_ProgressChanged(IDownloadProgress progress)
        {
            Console.WriteLine(progress.Status + " " + progress.BytesDownloaded);
        }

        static void Upload_ProgressChanged(IUploadProgress progress)
        {
            Console.WriteLine(progress.Status + " " + progress.BytesSent);
        }

        static void Upload_ResponseReceived(File file)
        {
            uploadedFile = file;
        }
        #endregion


    }
}
