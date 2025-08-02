public record FacialFeatures(string EyeColor, decimal PhiltrumWidth);

public record Identity(string Email, FacialFeatures FacialFeatures);

public class Authenticator
{
    private HashSet<Identity> _identities = new();
    private readonly Identity _admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(_admin);

    public bool Register(Identity identity) => _identities.Add(identity);

    public bool IsRegistered(Identity identity) => _identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => Object.ReferenceEquals(identityA, identityB);
}
