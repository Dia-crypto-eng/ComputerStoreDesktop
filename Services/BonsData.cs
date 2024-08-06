using ComputerStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStore.DATA
{
    class BonsData
    {
        public void addBons()
        {

        }
        public void deleteBons()
        {

        }
        public List<SellInoiceModel> bns = new List<SellInoiceModel>();
        //public List<BonsElement> bnse = new List<BonsElement>();
        public List<SellInoiceModel> GetAllBons() {
            
            bns.Add( new SellInoiceModel(){ 
            Id = 001,
            BnDate = "13/12/2021",
            Montant=5500,
            NameClient = "Kamal Boualag",
            Sold = "PAID",
           
            });

            bns.Add(new SellInoiceModel()
            {
                Id = 001,
                BnDate = "13/12/2021",
                Montant = 5500,
                NameClient = "Kamal Boualag",
                Sold = "PAID",

            });

            bns.Add(new SellInoiceModel()
            {
                Id = 001,
                BnDate = "13/12/2021",
                Montant = 5500,
                NameClient = "Kamal Boualag",
                Sold = "PAID",

            });

            bns.Add(new SellInoiceModel()
            {
                Id = 001,
                BnDate = "13/12/2021",
                Montant = 5500,
                NameClient = "Kamal Boualag",
                Sold = "UNPAID",

            });

            bns.Add(new SellInoiceModel()
            {
                Id = 001,
                BnDate = "13/12/2021",
                Montant = 5500,
                NameClient = "Kamal Boualag",
                Sold = "UNPAID",

            });

            bns.Add(new SellInoiceModel()
            {
                Id = 001,
                BnDate = "13/12/2021",
                Montant = 5500,
                NameClient = "Kamal Boualag",
                Sold = "UNPAID",

            });
            return bns;
        }

        //public List<BonsElement> GetBons()
        //{
        //    bnse.Add(new BonsElement()
        //    {
        //        Id = 001,
        //        FamilyProduct = "Machine a Laver",
        //        CodeProduct = "XPB65SB",
        //        Product = "Machine a Laver 6.5 KG Sans Pompe",
        //        PriceSell = 9500,
        //        Quantity = 6,
        //        Amount = 9500 * 6,

        //    }) ;
        //    bnse.Add(new BonsElement()
        //    {
        //        Id = 001,
        //        FamilyProduct = "Machine a Laver",
        //        CodeProduct = "XPB65SB",
        //        Product = "Machine a Laver 6.5 KG Sans Pompe",
        //        PriceSell = 9500,
        //        Quantity = 6,
        //        Amount = 9500 * 6,

        //    });
        //    bnse.Add(new BonsElement()
        //    {
        //        Id = 001,
        //        FamilyProduct = "Machine a Laver",
        //        CodeProduct = "XPB65SB",
        //        Product = "Machine a Laver 6.5 KG Sans Pompe",
        //        PriceSell = 9500,
        //        Quantity = 6,
        //        Amount = 9500 * 6,

        //    });
        //    bnse.Add(new BonsElement()
        //    {
        //        Id = 001,
        //        FamilyProduct = "Machine a Laver",
        //        CodeProduct = "XPB65SB",
        //        Product = "Machine a Laver 6.5 KG Sans Pompe",
        //        PriceSell = 9500,
        //        Quantity = 6,
        //        Amount = 9500 * 6,

        //    });
        //    bnse.Add(new BonsElement()
        //    {
        //        Id = 001,
        //        FamilyProduct = "Machine a Laver",
        //        CodeProduct = "XPB65SB",
        //        Product = "Machine a Laver 6.5 KG Sans Pompe",
        //        PriceSell = 9500,
        //        Quantity = 6,
        //        Amount = 9500 * 6,

        //    });

            

        //    return bnse;

        //}

    }
}
