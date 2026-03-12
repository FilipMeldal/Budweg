using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Dashboard.ViewModels
{
    public class MainViewModel 
    {
        //private EnergyRepo _energyRepo;
        //private WasteRepo _wasteRepo;
        //private BrakeCaliperRepo _brakeRepo;
        

        public ObservableCollection<InspectionViewModel> InspectionVM;
        public ObservableCollection<Co2ViewModel> Co2VM;
        private Co2Repo _co2Repo;
        private InspectionRepo _inspectionRepo;




    }
}
