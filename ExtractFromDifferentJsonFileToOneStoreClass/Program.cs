
using ExtractFromDifferentJsonFileToOneStoreClass;

Store s = new Store();

foreach (var item in s.Groups)
{
    Console.WriteLine(item.Id + " " + item.Name);
}

foreach (var item in s.Products)
{
    Console.WriteLine(item.Id + " " + item.Group + " " + item.Name + " " + item.Price + " " + item.Description);
}

foreach (var item in s.ProductGroups)
{
    Console.WriteLine(item.Id + " " + item.Name + " " + item.Price + " " + item.Description + " [Group: " + item.Group.Id + " " + item.Name + "]");
}













