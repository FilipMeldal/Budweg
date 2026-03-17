using Dashboard.Commands;
using Dashboard.Models;
using Dashboard.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Dashboard.ViewModels
{
    public class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<InspectionViewModel> InspectionVM; //laver en ny liste af inspections med værdierne fra InspectionViewModel
        public ObservableCollection<Co2ViewModel> Co2VM;
        private Co2Repo _co2Repo;
        private InspectionRepo _inspectionRepo;

        private InspectionViewModel selectedInspection;
        public ICommand SaveInspectionCommand { get; }


        public InspectionViewModel SelectedInspection
        {
            get { return selectedInspection; }
            set
            {
                selectedInspection = value;
                OnPropertyChanged("SelectedInspection"); //hvilken inspection som skal vises i UI, dvs. om det er for 30 dage eller 7 dage
            }
        }


        private readonly Inspection _inspection;
        public Inspection Inspection
        {
            get => Inspection;
            set { Inspection = value; OnPropertyChanged(); }
        }


        //private EnergyRepo _energyRepo;
        //private WasteRepo _wasteRepo;
        //private BrakeCaliperRepo _brakeRepo;

        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel { get => _navigationStore.CurrentViewModel; }

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _inspectionRepo = new InspectionRepo(); //ny instans af inspectionRepo
        }


        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
