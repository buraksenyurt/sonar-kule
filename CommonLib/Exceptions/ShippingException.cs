namespace CommonLib.Exceptions;

public class ShippingException
    : Exception
{
    public ShippingException()
        : base("Sipariş işleminde oluşan genel hata. Lütfen sistem yöneticisine başvurun veya ticket açın.")
    {
    }
}
