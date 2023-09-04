export interface MenuItems {
  title: string;
  icon: string;
  link: string;
  divider?: boolean;
}

export interface TableColumn {
  /**
   * nom de la colonne
   */
  name: string;

  /**
   * nom de la clé des données réelles dans cette colonne
   */
  dataKey: string; 

  /**
   * doit-elle être alignée à droite ou à gauche ?
   */
  position?: 'right' | 'left';

  /**
   * est-ce qu'une colonne peut être triée ?
   */
  isSortable?: boolean;
}