// -----------------------------------------
// --------- Made By Andrax ----------------
// andrax@andrax.nl  |  http://www.andrax.nl
// github.com/andraxb
// Copyright (c) Andrax
// -----------------------------------------
using System;
using System.Globalization;

namespace Andraxb.Maps
{
	/// <summary>
	/// Rijksdriehoek component.
	/// Helper class For converting from Rijksdriehoek to LatLong (WSG84) and vice versa.
	/// </summary>
	public static class RijksdriehoekComponent
	{
		/// <summary>
		/// Converts Rijksdriehoek coordinates to Latitude and Longitude.
		/// </summary>
		/// <returns>The lat long in string formatted as "{0}, {1}" where {0} is Lat and {1} is Long.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public static string ConvertToLatLong(double x, double y)
		{
			string result = null;

			// The city "Amsterfoort" is used as reference "Rijksdriehoek" coordinate.
			int referenceRdX = 155000;
			int referenceRdY = 463000;

			double dX = (double)(x - referenceRdX) * (double)(Math.Pow(10,-5));
			double dY = (double)(y - referenceRdY) * (double)(Math.Pow(10,-5));

			double sumN =
				(3235.65389 * dY) +
				(-32.58297 * Math.Pow(dX, 2)) +
				(-0.2475 * Math.Pow(dY, 2)) +
				(-0.84978 * Math.Pow(dX, 2) * dY) +
				(-0.0655 * Math.Pow(dY, 3)) +
				(-0.01709 * Math.Pow(dX, 2) * Math.Pow(dY, 2)) +
				(-0.00738 * dX) +
				(0.0053 * Math.Pow(dX, 4)) +
				(-0.00039 * Math.Pow(dX, 2) * Math.Pow(dY, 3)) +
				(0.00033 * Math.Pow(dX, 4) * dY) +
				(-0.00012 * dX * dY);
			double sumE =
				(5260.52916 * dX) +
				(105.94684 * dX * dY) +
				(2.45656 * dX * Math.Pow(dY, 2)) +
				(-0.81885 * Math.Pow(dX, 3)) +
				(0.05594 * dX * Math.Pow(dY, 3)) +
				(-0.05607 * Math.Pow(dX, 3) * dY) +
				(0.01199 * dY) +
				(-0.00256 * Math.Pow(dX, 3) * Math.Pow(dY, 2)) +
				(0.00128 * dX * Math.Pow(dY, 4)) +
				(0.00022 * Math.Pow(dY, 2)) +
				(-0.00022 * Math.Pow(dX, 2)) +
				(0.00026 * Math.Pow(dX, 5));


			// The city "Amsterfoort" is used as reference "WGS84" coordinate.
			double referenceWgs84X = 52.15517;
			double referenceWgs84Y = 5.387206;

			double latitude = referenceWgs84X + (sumN / 3600);
			double longitude = referenceWgs84Y + (sumE / 3600);

			result = string.Format("{0}, {1}",
				latitude.ToString(CultureInfo.InvariantCulture.NumberFormat),
				longitude.ToString(CultureInfo.InvariantCulture.NumberFormat));

			return result;
		}

		/// <summary>
		/// Converts to a LatLong object.
		/// </summary>
		/// <returns>The to LatLong object.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public static LatLong ConvertToLatLongObject(double x, double y)
		{
			string result = null;

			// The city "Amsterfoort" is used as reference "Rijksdriehoek" coordinate.
			int referenceRdX = 155000;
			int referenceRdY = 463000;

			double dX = (double)(x - referenceRdX) * (double)(Math.Pow(10,-5));
			double dY = (double)(y - referenceRdY) * (double)(Math.Pow(10,-5));

			double sumN =
				(3235.65389 * dY) +
				(-32.58297 * Math.Pow(dX, 2)) +
				(-0.2475 * Math.Pow(dY, 2)) +
				(-0.84978 * Math.Pow(dX, 2) * dY) +
				(-0.0655 * Math.Pow(dY, 3)) +
				(-0.01709 * Math.Pow(dX, 2) * Math.Pow(dY, 2)) +
				(-0.00738 * dX) +
				(0.0053 * Math.Pow(dX, 4)) +
				(-0.00039 * Math.Pow(dX, 2) * Math.Pow(dY, 3)) +
				(0.00033 * Math.Pow(dX, 4) * dY) +
				(-0.00012 * dX * dY);
			double sumE =
				(5260.52916 * dX) +
				(105.94684 * dX * dY) +
				(2.45656 * dX * Math.Pow(dY, 2)) +
				(-0.81885 * Math.Pow(dX, 3)) +
				(0.05594 * dX * Math.Pow(dY, 3)) +
				(-0.05607 * Math.Pow(dX, 3) * dY) +
				(0.01199 * dY) +
				(-0.00256 * Math.Pow(dX, 3) * Math.Pow(dY, 2)) +
				(0.00128 * dX * Math.Pow(dY, 4)) +
				(0.00022 * Math.Pow(dY, 2)) +
				(-0.00022 * Math.Pow(dX, 2)) +
				(0.00026 * Math.Pow(dX, 5));


			// The city "Amsterfoort" is used as reference "WGS84" coordinate.
			double referenceWgs84X = 52.15517;
			double referenceWgs84Y = 5.387206;

			double latitude = referenceWgs84X + (sumN / 3600);
			double longitude = referenceWgs84Y + (sumE / 3600);

			return new LatLong() {
				Lat = latitude,
				Long = longitude
			};
		}

		/// <summary>
		/// Converts Lat/Lon to rijksdriehoek.
		/// </summary>
		/// <returns>The to rijksdriehoek.</returns>
		/// <param name="wgs84_lattitude">Wgs84 lattitude.</param>
		/// <param name="wgs84_longitude">Wgs84 longitude.</param>
		public static RijksDriehoek ConvertToRijksdriehoek(double wgs84_lattitude, double wgs84_longitude)
		{
			// The city “Amsterfoort” is used as reference “Rijksdriehoek” coordinate.
			int referenceRdX = 155000;
			int referenceRdY = 463000;

			// The city “Amsterfoort” is used as reference “WGS84” coordinate.
			double referenceWgs84X = 52.15517;
			double referenceWgs84Y = 5.387206;

			var Rpq = new double[4, 5];
			Rpq[0, 1] = 190094.945;
			Rpq[1, 1] = -11832.228;
			Rpq[2, 1] = -114.221;
			Rpq[0, 3] = -32.391;
			Rpq[1, 0] = -0.705;
			Rpq[3, 1] = -2.340;
			Rpq[0, 2] = -0.008;
			Rpq[1, 3] = -0.608;
			Rpq[2, 3] = 0.148;
			var Spq = new double[4, 5];
			Spq[0, 1] = 0.433;
			Spq[0, 2] = 3638.893;
			Spq[0, 4] = 0.092;
			Spq[1, 0] = 309056.544;
			Spq[2, 0] = 73.077;
			Spq[1, 2] = -157.984;
			Spq[3, 0] = 59.788;
			Spq[2, 2] = -6.439;
			Spq[1, 1] = -0.032;
			Spq[1, 4] = -0.054;

			var d_lattitude = (0.36 * (wgs84_lattitude - referenceWgs84X));
			var d_longitude = (0.36 * (wgs84_longitude - referenceWgs84Y));
			double calc_latt = 0;
			double calc_long = 0;

			for (int p = 0; p < 4; p++)
			{
				for (int q = 0; q < 5; q++)
				{
					calc_latt += Rpq[p, q] * Math.Pow(d_lattitude, p) * Math.Pow(d_longitude, q);
					calc_long += Spq[p, q] * Math.Pow(d_lattitude, p) * Math.Pow(d_longitude, q);
				}
			}
			var rd_x_coordinate = (referenceRdX + calc_latt);
			var rd_y_coordinate = (referenceRdY + calc_long);

			return new RijksDriehoek (rd_x_coordinate, rd_y_coordinate);
		}
	}

	public class RijksDriehoek
	{
		/// <summary>
		/// Gets or sets the x.
		/// </summary>
		/// <value>The x.</value>
		public double X {get;set;}
		/// <summary>
		/// Gets or sets the y.
		/// </summary>
		/// <value>The y.</value>
		public double Y {get;set;}

		public RijksDriehoek(double x, double y ) {
			this.X = x;
			this.Y = y;
		}
	}

	public class LatLong
	{
		/// <summary>
		/// Gets or sets the latitude.
		/// </summary>
		/// <value>The latitude.</value>
		public double Lat {get;set;}
		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		public double Long {get;set;}
	}
}
