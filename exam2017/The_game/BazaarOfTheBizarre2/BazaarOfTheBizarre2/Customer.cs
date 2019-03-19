using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BazaarOfTheBizarre2 {
	class Customer {

		//***********Fields*************
		private string _name;
		private List<Store> _stores;
		bool _isRunning = true;


		//***********Constructors*************
		public Customer(string name, List<Store> stores) {
			_name = name;
			_stores = stores;
		}


		//***********Accessor and Mutator Methods*************
		public string Name {
			get => _name;
			set => _name = value;
		}

		public bool IsRunning {
			get => _isRunning;
			set => _isRunning = value;
		}


		//***********Methods*************
		public void Start() {
			Store CurrentStore;
			IProduct ItemBought;

			while (IsRunning) {

				for (int i = 0; i < _stores.Count(); i++) {
					CurrentStore = _stores.ElementAt(i);
					ItemBought = CurrentStore.SellItem();

					if (ItemBought == null) {
						continue;
					}
					
					Console.WriteLine("Purchase done: \n" + ItemBought.Name + " was purchased by: " + Name + "\n");
					ItemBought = null;
					Thread.Sleep(1500);
				}	
			}
		}	
	}
}
