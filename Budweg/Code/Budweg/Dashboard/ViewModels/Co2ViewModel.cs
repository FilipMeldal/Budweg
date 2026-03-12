using Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.ViewModels
{
    public class Co2ViewModel
    {
        private Co2Emission _co2EmissionWeight;
        public double Weight {  get { return _co2EmissionWeight.Weight; } set { _co2EmissionWeight.Weight = value; } }


        public Co2ViewModel(Co2Emission co2Emission)
        {
            _co2EmissionWeight = co2Emission;
        }
    }
}
