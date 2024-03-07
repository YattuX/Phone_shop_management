namespace Kada.Domain.Enums
{
    public enum EtatReparation
    {
        EnAttente,
        EnCours,
        Terminee,
        Restituee
    }
    public static class EtatReparationExtensions
    {
        public static EtatReparation NextEtape(this EtatReparation currentEtat)
        {
            switch (currentEtat)
            {
                case EtatReparation.EnAttente:
                    return EtatReparation.EnCours;
                case EtatReparation.EnCours:
                    return EtatReparation.Terminee;
                case EtatReparation.Terminee:
                    return EtatReparation.Restituee;
                case EtatReparation.Restituee:
                    // Si tu veux que ça boucle => return EtatReparation.EnAttente;
                    return EtatReparation.Restituee;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentEtat), currentEtat, null);
            }
        }
    }

}
