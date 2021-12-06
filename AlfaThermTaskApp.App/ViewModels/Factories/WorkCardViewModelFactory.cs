﻿using AlfaThermTaskApp.App.State.Authenticator;
using AlfaThermTaskApp.App.State.Navigators;
using AlfaThermTaskApp.DataAccess.IServices;
using AlfaThermTaskApp.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaThermTaskApp.App.ViewModels.Factories
{
    public class WorkCardViewModelFactory : IViewModelFactory<WorkCardViewModel>
    {
        private readonly IPermissionService permissionService;
        private readonly INavigator navigator;
        private readonly IDataService<WorkCard> dataService;
        private readonly IAuthenticator authenticator;
        private readonly IDataService<Projects> projectsDataService;

        public WorkCardViewModelFactory(IPermissionService permissionService, INavigator navigator, IDataService<WorkCard> dataService, IAuthenticator authenticator, IDataService<Projects> projectsDataService)
        {
            this.permissionService = permissionService;
            this.navigator = navigator;
            this.dataService = dataService;
            this.authenticator = authenticator;
            this.projectsDataService = projectsDataService;
        }

        public WorkCardViewModel CreateViewModel(object parameter = null)
        {
            return new WorkCardViewModel(permissionService, navigator, dataService, authenticator, projectsDataService);
        }
    }
}
