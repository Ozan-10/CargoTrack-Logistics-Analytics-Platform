using System.Globalization;
using System.Text;

var cities = new[]
{
    "Istanbul",
    "Ankara",
    "Izmir",
    "Bursa",
    "Antalya",
    "Konya",
    "Adana",
    "Gaziantep",
    "Kayseri",
    "Samsun"
};

var statuses = new[]
{
    "Delivered",
    "Delayed",
    "Preparing",
    "InTransit"
};

var random = new Random();

var path = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
    "CargoTrack_1M.csv");

using var writer =
    new StreamWriter(path, false, Encoding.UTF8);

writer.WriteLine(
"TrackingCode,SenderCity,ReceiverCity,BranchId,CourierId,Status,Weight,ShippingPrice,ShipmentDate,DeliveryDate");

for (int i = 1; i <= 1_000_000; i++)
{
    string trackingCode = $"CTR-{i:0000000}";

    string senderCity =
        cities[random.Next(cities.Length)];

    string receiverCity;

    do
    {
        receiverCity =
            cities[random.Next(cities.Length)];
    }
    while (receiverCity == senderCity);

    int branchId =
        random.Next(1, 6);

    int courierId =
        random.Next(1, 6);

    string status =
        statuses[random.Next(statuses.Length)];

    string weight =
        (random.NextDouble() * 20 + 1)
        .ToString("0.00", CultureInfo.InvariantCulture);

    string shippingPrice =
        (random.NextDouble() * 500 + 50)
        .ToString("0.00", CultureInfo.InvariantCulture);

    DateTime shipmentDate =
        DateTime.Today.AddDays(
            -random.Next(1, 365));

    DateTime deliveryDate =
        shipmentDate.AddDays(
            random.Next(1, 8));

    writer.WriteLine(
        $"{trackingCode}," +
        $"{senderCity}," +
        $"{receiverCity}," +
        $"{branchId}," +
        $"{courierId}," +
        $"{status}," +
        $"{weight}," +
        $"{shippingPrice}," +
        $"{shipmentDate:yyyy-MM-dd}," +
        $"{deliveryDate:yyyy-MM-dd}");
}

Console.WriteLine("1M CSV generated successfully.");