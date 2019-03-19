using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BazaarOfTheBizarre2 {
	class ProductFactory {

		//***********Fields*************
		static private Object _Lock2 = new Object();   // lock variable
		static int number = 1; // variable that we use to give every product a unique name

		
		//***********Constructors*************
		public ProductFactory() {
		
		}


		//***********Methods*************
	
			static public IProduct CreateProduct() // A method that creates a random product by using createRandom
			{
	
				lock (_Lock2)
				{
					IProduct item = new Product(CreateRandom() + "#" + String.Concat(number));
			
					number++;      	
					
					return item;
				}

			}
	

		static public string CreateRandom() //method that chooses a random product
		{
            Random random = new Random(Guid.NewGuid().GetHashCode());
			int rnd = random.Next(1, 11);

			switch (rnd) {
				case 1:
					return "Car";
					
				case 2:
                    return "Horse";
					
				case 3:
                    return "Diamond Necklace";
					
				case 4:
                    return "Chair";
					
				case 5:
                    return "Painting";
					
				case 6:
                    return "Tv";
					
				case 7:         
					return "Sword";
	            		            
	            case 8:         
					return "IBM computer";
	            
				case 9:         
					return "Sandals";
	            
						            
				case 10:         
					return "Chain Mail";
	            
				default:
                    return "Shoes";
					
			}
		}
	}
}
