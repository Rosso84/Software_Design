using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BazaarOfTheBizarre2 {
	class Controller {

        //***********Fields*************
		private List<Thread> _storeThreads;
		private List<Thread> _customerThreads;
		private List<Customer> _customerList;
        private List<Store> _storeList; 


		//***********Constructors*************
		public Controller()
		{
			_storeThreads = new List<Thread>();
			_customerThreads = new List<Thread>();
			_customerList = new List<Customer>();
			_storeList = new List<Store>();
		}


		//***********Methods*************
		public void Start()
		{
			Console.WriteLine("Welcome to the Bazar of the bizarre ! \n");
			for (int i = 0; i < 5; i++)
			{
				_storeList.Add(new Store("Store " + String.Concat(i + 1)));
				_storeThreads.Add(new Thread(_storeList[i].Start));
				_storeThreads.ElementAt(i).Start();
				    
			}
			for (int i = 0; i < 5; i++) {
				_customerList.Add(new Customer("Customer " + String.Concat(i + 1), _storeList));
				Console.WriteLine(_customerList[i].Name + " has arrived at the bazaar and is ready to buy \n");
				Thread.Sleep(1000);
				_customerThreads.Add(new Thread(_customerList[i].Start));
				_customerThreads.ElementAt(i).Start();
			}
			Thread.Sleep(10000);
			StopStores();
			Thread.Sleep(12000);
			StopCustomers();

			CloseThreads(_storeThreads);
			CloseThreads(_customerThreads);
		}
       
        public void CloseThreads(List<Thread> threads){
            for(int i = 0; i < threads.Count(); i++){
                threads.ElementAt(i).Join();
            }
        }

		public void StopStores() {
			for(int i = 0; i < _storeList.Count(); i++) {
				_storeList.ElementAt(i).IsRunning = false;
			}
		}

		public void StopCustomers() {
			for (int i = 0; i < _customerList.Count(); i++) {
				_customerList.ElementAt(i).IsRunning = false;
			}
		}
	}
}
