/**
 * @(#) Trip.cs
 */

namespace Projektas.Models
{
	public class Trip
	{
		Integer id;
		
		Integer length;
		
		Integer distance;
		
		date date;
		
		double price;
		
		Discount assignedDiscount;
		
		Fine fineForTheTrip;
		
		Car tripCar;
		
		Client client;
		
		TripType state;
		
		public void updateTrip(  )
		{
			
		}
		
		public void create( int car_id )
		{
			
		}
		
	}
	
}
