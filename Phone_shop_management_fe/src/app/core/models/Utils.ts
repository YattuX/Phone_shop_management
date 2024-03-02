export class TypeArticleName{
    static telephone = "Téléphone";
    static tablette = "Tablette";
    static pochette = "Pochette";
    static microEtVibreur = "Micro et Vibreur";
    static conectiques = "Conectiques";
    static ecran = "Ecran";
    static dépoussiérant = "Dépoussiérant";
    static appareilAccessoir = "Appareil-accessoir";
    static diluant = "Diluant";
    static napeEtPlaquette = "Napes et Plaquettes";
    static moteur = "Moteur";
    static vitre = "Vitre";
    static batterie = "Batterie";
    static hautParleur = "Haut-Parleur";
    static camera = "Camera";
    static ordinateur = "Ordinateur";
    static instrument = "Intrument";
    static cadre = "Cadre";
    static antiCasse ="Anti-casse"
}

export enum StatutPaiement {
    Impaye,
    PartiellementPaye,
    Paye
}

export const statutPaiementValues: { name: string, id: number }[] = [
    { name: "Impayée", id: StatutPaiement.Impaye },
    { name: "Partiellement Payée", id: StatutPaiement.PartiellementPaye },
    { name: "Payée", id: StatutPaiement.Paye }
];

export enum EtatReparation {
    EnAttente,
    EnCours,
    Terminee,
    Restituee
}

export const etatsReparationValues: { name: string, id: number }[] = [
    { name: "En Attente", id: EtatReparation.EnAttente },
    { name: "En Cours", id: EtatReparation.EnCours },
    { name: "Terminée", id: EtatReparation.Terminee },
    { name: "Restituée", id: EtatReparation.Restituee }
];


/**
 * Représente un rôle d'identité dans le système.
 * Chaque rôle est défini par un identifiant unique, un nom et une version normalisée du nom.
 */
export type IdentityRole = {
    /** L'identifiant unique du rôle. */
    readonly Id: string;
    /** Le nom du rôle. */
    readonly Name: string;
    /** Le nom normalisé du rôle, en majuscules. */
    readonly NormalizedName: string;
};


/**
 * Représente le rôle de Vendeur dans le système.
 * Les vendeurs ont des privilèges pour gérer les ventes et les transactions.
 */
export const VENDEUR_ROLE: IdentityRole = {
    Id: "cac43a6e-f22b-4448-baaf-1add431ccbbf",
    Name: "Vendeur",
    NormalizedName: "VENDEUR"
};

/**
 * Représente le rôle de Technicien dans le système.
 * Les techniciens ont des privilèges pour résoudre des problèmes techniques et effectuer des réparations.
 */
export const TECHNICIEN_ROLE: IdentityRole = {
    Id: "cbc43a8e-57bb-4445-baaf-1add431ffbbc",
    Name: "Technicien",
    NormalizedName: "TECHNICIEN"
};

/**
 * Représente le rôle d'Administrateur dans le système.
 * Les administrateurs ont des privilèges étendus pour gérer les utilisateurs, les autorisations et les configurations du système.
 */
export const ADMINISTRATOR_ROLE: IdentityRole = {
    Id: "cbc43a8e-f34b-4445-baaf-1add431ffbbr",
    Name: "Administrateur",
    NormalizedName: "ADMINISTRATOR"
};

