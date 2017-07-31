using SimOnline.Model.Models;
using SimOnline.Web.Models;

namespace SimOnline.Web.Infrastructure.Extensions
{
    internal static class EntityExtensions
    {
        public static void UpdateSimNetwork(this SimNetwork simNetwork, SimNetworkViewModel simNetworkViewModel)
        {
            simNetwork.ID = simNetworkViewModel.ID;
            simNetwork.Name = simNetworkViewModel.Name;
            simNetwork.Alias = simNetworkViewModel.Alias;
            simNetwork.Image = simNetworkViewModel.Image;
            simNetwork.Description = simNetworkViewModel.Description;
            simNetwork.MetaKeyword = simNetworkViewModel.MetaKeyword;
            simNetwork.MetaDescription = simNetworkViewModel.MetaDescription;
            simNetwork.HomeFlag = simNetworkViewModel.HomeFlag;
            simNetwork.CreateDate = simNetworkViewModel.CreateDate;
            simNetwork.CreateBy = simNetworkViewModel.CreateBy;
            simNetwork.UpdateDate = simNetworkViewModel.UpdateDate;
            simNetwork.UpdateBy = simNetworkViewModel.UpdateBy;
            simNetwork.Status = simNetworkViewModel.Status;
            simNetwork.DisplayOrder = simNetworkViewModel.DisplayOrder;
        }

        public static void UpdateFirstNumber(this FirstNumber firstNumber, FirstNumberViewModel firstNumberViewModel)
        {
            firstNumber.FirstNumberID = firstNumberViewModel.FirstNumberID;
            firstNumber.NetworkID = firstNumberViewModel.NetworkID;
            firstNumber.FirstNumberName = firstNumberViewModel.FirstNumberName;
            firstNumber.Description = firstNumberViewModel.Description;
            firstNumber.Alias = firstNumberViewModel.Alias;
            firstNumber.HomeFlag = firstNumberViewModel.HomeFlag;
            firstNumber.MetaDescription = firstNumberViewModel.MetaDescription;
            firstNumber.MetaKeyword = firstNumberViewModel.MetaKeyword;
            firstNumber.CreateDate = firstNumberViewModel.CreateDate;
            firstNumber.CreateBy = firstNumberViewModel.CreateBy;
            firstNumber.UpdateDate = firstNumberViewModel.UpdateDate;
            firstNumber.UpdateBy = firstNumberViewModel.UpdateBy;
            firstNumber.Status = firstNumberViewModel.Status;
            firstNumber.DisplayOrder = firstNumberViewModel.DisplayOrder;
        }

        public static void UpdateSimNumber(this SimNumber simNumber, SimNumberViewModel simNumberViewModel)
        {
            simNumber.SimID = simNumberViewModel.SimID;
            simNumber.SimName = simNumberViewModel.SimName;
            simNumber.NetWorkID = simNumberViewModel.NetWorkID;
            simNumber.ConsignerID = simNumberViewModel.ConsignerID;
            simNumber.Price = simNumberViewModel.Price;
            simNumber.CreateDate = simNumberViewModel.CreateDate;
            simNumber.UpdateDate = simNumberViewModel.UpdateDate;
            simNumber.Status = simNumberViewModel.Status;
        }

        public static void UpdateConsigner(this Consigner consigner, ConsignerViewModel consignerViewModel)
        {
            consigner.ID = consignerViewModel.ID;
            consigner.Name = consignerViewModel.Name;
            consigner.ConsignerCode = consignerViewModel.ConsignerCode;
            consigner.Hotline = consignerViewModel.Hotline;
            consigner.Address = consignerViewModel.Address;
            consigner.Website = consignerViewModel.Website;
            consigner.Email = consignerViewModel.Email;
            consigner.CreateDate = consignerViewModel.CreateDate;
            consigner.CreateBy = consignerViewModel.CreateBy;
            consigner.UpdateDate = consignerViewModel.UpdateDate;
            consigner.UpdateBy = consignerViewModel.UpdateBy;
            consigner.Status = consignerViewModel.Status;
            consigner.DisplayOrder = consignerViewModel.DisplayOrder;
        }

        public static void UpdateConsignerLevel(this ConsignerLevel consignerLevel, ConsignerLevelViewModel consignerLevelViewModel)
        {
            consignerLevel.ID = consignerLevelViewModel.ID;
            consignerLevel.ConsignerID = consignerLevelViewModel.ConsignerID;
            consignerLevel.Name = consignerLevelViewModel.Name;
            consignerLevel.PriceFrom = consignerLevelViewModel.PriceFrom;
            consignerLevel.PriceFrom = consignerLevelViewModel.PriceFrom;
            consignerLevel.PriceTo = consignerLevelViewModel.PriceTo;
            consignerLevel.Percent = consignerLevelViewModel.Percent;
            consignerLevel.CreateDate = consignerLevelViewModel.CreateDate;
            consignerLevel.CreateBy = consignerLevelViewModel.CreateBy;
            consignerLevel.UpdateDate = consignerLevelViewModel.UpdateDate;
            consignerLevel.UpdateBy = consignerLevelViewModel.UpdateBy;
            consignerLevel.DisplayOrder = consignerLevelViewModel.DisplayOrder;
        }
    }
}