namespace ChickAndPaddy;

public class PartnerModel : BaseModel
{
    public Guid Id { get; set; }

    public string PairingId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string NickName { get; set; }

    public DateTime FirstMet { get; set; }
}

