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
            get { if (SelectedShippingService != null) return SelectedShippingService.ShippingLocation.DestinationZipCode; else return 0; }
            set { if(SelectedShippingService != null) SelectedShippingService.ShippingLocation.DestinationZipCode = value;}
        }

        public uint NumRefuels { get { if (SelectedDeliveryService != null) return SelectedShippingService.NumRefuels; else return 0; } }
        public uint ShippingDistance { get { if (SelectedShippingService != null) return SelectedShippingService.ShippingDistance; else return 0; } }

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
            if (selectedString.Contains("Default Shipping Service"))
            {
                IShippingService defaultService = new DefaultShippingService(SelectedDeliveryService, products, location);
                return defaultService;
            }
            else return null;
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

        public IShippingService SelectedShippingService;
        public IDeliveryService SelectedDeliveryService;//represents the service chosen by the combo box

        public void ExecuteCommandShowValues(object parameter)
        {
            SelectedShippingService = ConvertStringToShippingService(selectedShippingServiceString);
            SelectedDeliveryService = ConvertStringToDeliveryService(selectedDeliveryServiceString);

            RaisePropertyChanged("DestinationZipcode");
            RaisePropertyChanged("NumRefuels");
            RaisePropertyChanged("ShippingDistance");
        }

        public bool CanExecuteCommandShowValues(object parameter)//can only do this command if user chose
        {
            return true;
        }
    }
}
