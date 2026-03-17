using Dashboard.Commands;
using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Dashboard.ViewModels
{
    public class MainViewModel : DatabaseConnector, INotifyPropertyChanged
    {
        //private EnergyRepo _energyRepo;
        //private WasteRepo _wasteRepo;
        //private BrakeCaliperRepo _brakeRepo;
        

        public ObservableCollection<InspectionViewModel> InspectionVM; //laver en ny liste af inspections med værdierne fra InspectionViewModel
        public ObservableCollection<Co2ViewModel> Co2VM;
        private Co2Repo _co2Repo;
        private InspectionRepo _inspectionRepo;

        private InspectionViewModel selectedInspection;
        public InspectionViewModel SelectedInspection
        { 
            get { return selectedInspection; }
            set  
            {
                selectedInspection = value;
                OnPropertyChanged("SelectedInspection"); //hvilken inspection som skal vises i UI, dvs. om det er for 30 dage eller 7 dage
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? connectionString = null) //[callermembername] er en indbygget metode som er synonym for ethvert property som kan være inputs værdi og at det kan være og som standard er null
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(connectionString)); //Lambda expression som laver en ny instans med det nye property name. Her eksekveres metoden 




        public ICommand SaveInspectionCommand { get; } 



        public MainViewModel()
        {
            _inspectionRepo = new InspectionRepo(); //ny instans af inspectionRepo
            //_co2Repo = new Co2Repo("appsettings.json"); 

            InspectionVM = new ObservableCollection<InspectionViewModel>(); //lave en ny instans af InspectionVM hvor alle inspections kan ligge i som starter på nul
            //Co2VM = new ObservableCollection<Co2ViewModel>();
            foreach(Inspection inspection in _inspectionRepo.InspecGetAll()) //henter alle inspections og ligger dem ind i InspectionViewModel
            {
                InspectionVM.Add(new InspectionViewModel(inspection));
            }
            if(InspectionVM.Count > 0)
            {
                SelectedInspection = InspectionVM[InspectionVM.Count - 1]; //sætter den valgte inspection til at være lig med den nyeste inspection
            }

            SaveInspectionCommand = new SaveInspectionCommand(this); //gør det muligt at eksekvere SaveInspectionCommand


        }




        public void SaveInspection(Inspection inspection)
        {
            _inspectionRepo.InspecAdd(inspection);
        }

        
        


    }
}
