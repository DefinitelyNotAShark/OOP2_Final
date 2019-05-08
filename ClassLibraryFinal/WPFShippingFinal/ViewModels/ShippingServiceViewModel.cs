using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClassLibraryFinal;

namespace WPFShippingFinal.ViewModels
{
    partial class ShippingServiceViewModel : ViewModelBase
    {
        public IShippingService shippingService;
        public IDeliveryService deliveryService;
        private IShippingVehicle vehicle;

        private List<IProduct> products;
        private IShippingLocation location;


        public uint DestinationZipcode
        {
            get { return SelectedShippingService.ShippingLocation.DestinationZipCode; }
            set { SelectedShippingService.ShippingLocation.DestinationZipCode = value; }
        }

        public uint NumRefuels { get { return SelectedShippingService.NumRefuels; } }
        public uint ShippingDistance { get; set; }

        public ICommand ShowValues { get; set; }

        public ShippingServiceViewModel()
        {
            this.ShowValues = new ShippingServiceViewModelCommand(ExecuteCommandShowValues, CanExecuteCommandShowValues);
        }

        #region string properties
        private string selectedShippingServiceString;
           private string selectedDeliveryServiceString;

        public string SelectedShippingServiceString
        {
            get { return selectedShippingServiceString; }
            set { selectedShippingServiceString = value; }
        }

        public string SelectedDeliveryServiceString
        {
            get { return selectedDeliveryServiceString; }
            set { selectedDeliveryServiceString = value; }
        }
        #endregion//declarations of things to parse the strings from the combobox

        #region string conversion
        private IShippingService ConvertStringToShippingService(string selectedString)//represents the service chosen by the combobox
        {
            switch (selectedString)
            {
                case "DefaultShippingService":
                    IShippingService defaultService = new DefaultShippingService(SelectedDeliveryService, products, location);
                    return defaultService;
                default: return null; 
            }
        }

        private IDeliveryService ConvertStringToDeliveryService(string selectedString)
        {
            switch (selectedString)
            {
                case "Snail Service":
                    vehicle = new ShippingSnail();//vehicle instance based on delivery service chosen
                    DeliveryService snailService = new SnailService(vehicle);
                    return snailService;

                case "Uncle's Truck":
                    vehicle = new Truck();
                    DeliveryService truckService = new UnclesTruck(vehicle);
                    return truckService;

                default: return null;
            }
        }
        #endregion//parsing in the strings to be turned into interface instances

        public IShippingService SelectedShippingService
        {
            get {  return ConvertStringToShippingService(selectedShippingServiceString);  }
            set
            {
                IShippingService service = ConvertStringToShippingService(selectedShippingServiceString);
                service = value;
                RaisePropertyChanged();//get the different stuff in the things
            }
        }
    
        public IDeliveryService SelectedDeliveryService//represents the service chosen by the combo box
        {
            get {  return ConvertStringToDeliveryService(selectedDeliveryServiceString); }
            set
            {
                IDeliveryService service = ConvertStringToDeliveryService(selectedDeliveryServiceString);
                service = value;
            }
        }

        public void ExecuteCommandShowValues(object parameter)
        {
            RaisePropertyChanged("DestinationZipcode");
            RaisePropertyChanged("NumRefuels");
            RaisePropertyChanged("ShippingDistance");
        }

        public bool CanExecuteCommandShowValues(object parameter)//can only do this command if user chose
        {
            if (SelectedShippingService != null && SelectedDeliveryService != null)
                return true;

            else return false;
        }
    }
}
