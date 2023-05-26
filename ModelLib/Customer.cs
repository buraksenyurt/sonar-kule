namespace ModelLib;

public class Customer{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public MemberType MemberType { get; set; }
    public string City { get; set; }
}

public enum MemberType{
    Gold,
    Platinium,
    Regular
}