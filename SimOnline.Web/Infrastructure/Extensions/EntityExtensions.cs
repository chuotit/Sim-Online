using System;
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

        public static void UpdateSimStore(this SimStore simStore, SimStoreViewModel simStoreViewModel)
        {
            simStore.SimID = simStoreViewModel.SimID;
            simStore.SimName = simStoreViewModel.SimName;
            simStore.NetWorkID = simStoreViewModel.NetWorkID;
            simStore.AgentID = simStoreViewModel.AgentID;
            simStore.Price = simStoreViewModel.Price;
            simStore.Discount = simStoreViewModel.Discount;
            simStore.CreateDate = simStoreViewModel.CreateDate;
            simStore.UpdateDate = simStoreViewModel.UpdateDate;
            simStore.Status = simStoreViewModel.Status;
        }
        public static void UpdateSimAddNew(this SimStore simStore, SimStoreAddViewModel simAddNewViewModel)
        {
            simStore.SimName = simAddNewViewModel.SimName;
            simStore.Price = simAddNewViewModel.Price;
        }

        public static void UpdateAgent(this Agent agent, AgentViewModel agentViewModel)
        {
            agent.AgentId = agentViewModel.AgentId;
            agent.Name = agentViewModel.Name;
            agent.AgentCode = agentViewModel.AgentCode;
            agent.Hotline = agentViewModel.Hotline;
            agent.Address = agentViewModel.Address;
            agent.Website = agentViewModel.Website;
            agent.Email = agentViewModel.Email;
            agent.CreateDate = agentViewModel.CreateDate;
            agent.CreateBy = agentViewModel.CreateBy;
            agent.UpdateDate = agentViewModel.UpdateDate;
            agent.UpdateBy = agentViewModel.UpdateBy;
            agent.Status = agentViewModel.Status;
            agent.DisplayOrder = agentViewModel.DisplayOrder;
        }

        public static void UpdateAgentLevel(this AgentLevel agentLevel, AgentLevelViewModel agentLevelViewModel)
        {
            agentLevel.ID = agentLevelViewModel.ID;
            agentLevel.AgentID = agentLevelViewModel.AgentID;
            agentLevel.Name = agentLevelViewModel.Name;
            agentLevel.PriceFrom = agentLevelViewModel.PriceFrom;
            agentLevel.PriceFrom = agentLevelViewModel.PriceFrom;
            agentLevel.PriceTo = agentLevelViewModel.PriceTo;
            agentLevel.Percent = agentLevelViewModel.Percent;
            agentLevel.CreateDate = agentLevelViewModel.CreateDate;
            agentLevel.CreateBy = agentLevelViewModel.CreateBy;
            agentLevel.UpdateDate = agentLevelViewModel.UpdateDate;
            agentLevel.UpdateBy = agentLevelViewModel.UpdateBy;
            agentLevel.DisplayOrder = agentLevelViewModel.DisplayOrder;
        }

        public static void UpdateRegisterAgent(this Agent agent, AgentRegisterViewModel agentRegisterViewModel)
        {
            agent.AgentId = agentRegisterViewModel.AgentId;
            agent.Name = agentRegisterViewModel.Name;
            agent.Hotline = agentRegisterViewModel.Hotline;
            agent.Address = agentRegisterViewModel.Address;
            agent.CreateDate = agentRegisterViewModel.CreateDate;
            agent.CreateBy = agentRegisterViewModel.CreateBy;
            agent.UpdateDate = agentRegisterViewModel.UpdateDate;
            agent.UpdateBy = agentRegisterViewModel.UpdateBy;
            agent.Status = agentRegisterViewModel.Status;
            agent.DisplayOrder = agentRegisterViewModel.DisplayOrder;
        }

        public static void UpdateAppGroup(this AppGroup appGroup, AppGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }

        public static void UpdateAppRole(this AppRole appRole, AppRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this AppUser appUser, AppUserViewModel appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.AgentID = appUserViewModel.AgentID;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
        }

        public static void UpdateRegisterUser(this AppUser appUser, AgentRegisterViewModel agentRegisterViewModel)
        {

            appUser.UserName = agentRegisterViewModel.UserName;
            appUser.Email = agentRegisterViewModel.Email;
            appUser.AgentID = agentRegisterViewModel.AgentId;
        }
    }
}