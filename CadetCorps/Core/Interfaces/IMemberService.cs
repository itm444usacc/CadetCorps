using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CadetCorps.ViewModels;

namespace CadetCorps.Core.Interfaces
{
    public interface IMemberService
    {
        void CreateUser(CreateMemberViewModel viewModel);
    }
}