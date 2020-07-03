using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.masterHlepers
{
    public class ProductHelper
    {
        public List<TblProduct> GetProductList()
        {
            try
            {
                using Repository<TblProduct> repo = new Repository<TblProduct>();
                return repo.TblProduct.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblProductGroup> GetProductGroupList()
        {
            try
            {
                using Repository<TblProductGroup> repo = new Repository<TblProductGroup>();
                return repo.TblProductGroup.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblProductPacking> GetProductPackingList()
        {
            try
            {
                using Repository<TblProductPacking> repo = new Repository<TblProductPacking>();
                return repo.TblProductPacking.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblSupplierGroup> GetSupplierGroupList()
        {
            try
            {
                using Repository<TblSupplierGroup> repo = new Repository<TblSupplierGroup>();
                return repo.TblSupplierGroup.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblUnit> GetUnitList()
        {
            try
            {
                using Repository<TblUnit> repo = new Repository<TblUnit>();
                return repo.TblUnit.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblTaxGroup> GetTaxGroupList(decimal productGroup)
        {
            try
            {
                using Repository<TblTaxGroup> repo = new Repository<TblTaxGroup>();
                    return repo.TblTaxGroup.AsEnumerable().Where(tax=>tax.ProductGroupCode== productGroup).ToList();
            }
            catch { throw; }
        }

        public List<TblTaxapplicableOn> GetTaxApplicableList()
        {
            try
            {
                using Repository<TblTaxapplicableOn> repo = new Repository<TblTaxapplicableOn>();
                return repo.TblTaxapplicableOn.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblTaxGroup> GetTaxGroup()
        {
            try
            {
                using Repository<TblTaxGroup> repo = new Repository<TblTaxGroup>();
                return repo.TblTaxGroup.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblTaxStructure> GetTaxStructure()
        {
            try
            {
                using Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>();
                return repo.TblTaxStructure.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<TblTaxStructure> GetTaxStructureList(string taxGroupCode=null)
        {
            try
            {
                using Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>();
                if (string.IsNullOrEmpty(taxGroupCode))
                {
                    return repo.TblTaxStructure.AsEnumerable().ToList();
                }
                else
                {
                    return repo.TblTaxStructure.AsEnumerable().Where(tax => tax.TaxGroupCode == taxGroupCode).ToList();
                }
            }
            catch { throw; }
        }

        public List<TblTaxStructure> GetTaxList(int taxStructureCode = 0)
        {
            try
            {
                using Repository<TblTaxStructure> repo = new Repository<TblTaxStructure>();
                if (taxStructureCode == 0)
                {
                    return repo.TblTaxStructure.AsEnumerable().ToList();
                }
                else
                {
                    return repo.TblTaxStructure.AsEnumerable().Where(tax => tax.TaxStructureCode == taxStructureCode).ToList();
                }
            }
            catch { throw; }
        }
        public TblProduct Register(TblProduct product)
        {
            try
            {
                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    var record = repo.TblProduct.OrderByDescending(x => x.ProductId).FirstOrDefault();
                    if (record != null)
                    {
                        product.ProductId = Convert.ToInt32(CommonHelper.IncreaseCode(record.ProductId.ToString()));
                    }
                    else
                    {
                        product.ProductId = 1;
                    }
                    var _supplier = GetSupplierGroupList().Where(x => x.SupplierGroupName == product.SupplierName).ToArray().FirstOrDefault();
                    var _product = GetProductGroupList().Where(x=>x.GroupCode==product.ProductGroupCode).ToArray().FirstOrDefault();
                    var _productpacking = GetProductPackingList().Where(x => x.PackingCode == product.PackingCode).ToArray().FirstOrDefault();
                    var _taxgroup = GetTaxGroup().Where(x => x.TaxGroupCode == product.TaxGroupCode).ToArray().FirstOrDefault();
                    var _unit = GetUnitList().Where(x => x.UnitId == product.UnitId).FirstOrDefault();
                    var _taxstructure = GetTaxStructure().Where(x => x.TaxStructureCode == product.TaxStructureCode).ToArray().FirstOrDefault();
                    var _taxapplicable = GetTaxApplicableList().Where(x => x.Id == product.TaxapplicableOnId).ToArray().FirstOrDefault();
                    product.PackingId = _productpacking.PackingId;
                    product.PackingName = _productpacking.PackingName;
                    product.ProductGroupId = _product.GroupId;
                    product.ProductGroupName = _product.GroupName;
                    product.TaxGroupId = _taxgroup.TaxGroupId;
                    product.TaxGroupName = _taxgroup.TaxGroupName;
                    product.UnitName = _unit.UnitName;
                    product.TaxapplicableOn = _taxapplicable.Name;
                    product.SupplierId = _supplier.SupplierGroupId;
                    product.SupplierCode = Convert.ToInt64(_supplier.SupplierGroupCode);
                    product.TaxStructureId = _taxstructure.TaxStructureId;
                    repo.TblProduct.Add(product);
                    if (repo.SaveChanges() > 0)
                        return product;
                }
                return null;
            }
            catch { throw; }
        }

        public TblProduct Update(TblProduct product)
        {
            try
            {
                using Repository<TblProduct> repo = new Repository<TblProduct>();
                var _supplier = GetSupplierGroupList().Where(x => x.SupplierGroupName == product.SupplierName).ToArray().FirstOrDefault();
                var _product = GetProductGroupList().Where(x => x.GroupCode == product.ProductGroupCode).ToArray().FirstOrDefault();
                var _productpacking = GetProductPackingList().Where(x => x.PackingCode == product.PackingCode).ToArray().FirstOrDefault();
                var _taxgroup = GetTaxGroup().Where(x => x.TaxGroupCode == product.TaxGroupCode).ToArray().FirstOrDefault();
                var _unit = GetUnitList().Where(x => x.UnitId == product.UnitId).FirstOrDefault();
                var _taxstructure = GetTaxStructure().Where(x => x.TaxStructureCode == product.TaxStructureCode).ToArray().FirstOrDefault();
                var _taxapplicable = GetTaxApplicableList().Where(x => x.Id == product.TaxapplicableOnId).ToArray().FirstOrDefault();
                product.PackingId = _productpacking.PackingId;
                product.PackingName = _productpacking.PackingName;
                product.ProductGroupId = _product.GroupId;
                product.ProductGroupName = _product.GroupName;
                product.TaxGroupId = _taxgroup.TaxGroupId;
                product.TaxGroupName = _taxgroup.TaxGroupName;
                product.UnitName = _unit.UnitName;
                product.TaxapplicableOn = _taxapplicable.Name;
                product.SupplierId = _supplier.SupplierGroupId;
                product.SupplierCode = Convert.ToInt64(_supplier.SupplierGroupCode);
                product.TaxStructureId = _taxstructure.TaxStructureId;
                repo.TblProduct.Update(product);
                if (repo.SaveChanges() > 0)
                    return product;

                return null;
            }
            catch { throw; }
        }
        public TblProduct Delete(int code)
        {
            try
            {
                using (Repository<TblProduct> repo = new Repository<TblProduct>())
                {
                    var product = repo.TblProduct.Where(x => x.ProductId == code).FirstOrDefault();
                    repo.TblProduct.Remove(product);
                    if (repo.SaveChanges() > 0)
                        return product;
                }
                return null;
            }
            catch { throw; }
        }
    }
}
