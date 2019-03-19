using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarOfTheBizarre2 {


	class Product : IProduct {

        private string _name;

		public Product(string name) {
			Name = name;
		}

		public string Name {
			get => _name; 
			set => _name = value;
		}
		
        public override string ToString() {
            return Name;
		}
	}
}
