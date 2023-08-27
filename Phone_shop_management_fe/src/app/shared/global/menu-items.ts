import { MenuItems } from "src/app/core/models/interfaces";

export const MENU_ITEMS: MenuItems[] = [
    { title: "Utilisateurs", icon: "manage_accounts", link: "a", divider: false },
    { title: "Clients", icon: "people", link: "b", divider: false },
    { title: "Fournisseurs", icon: "shop", link: "c", divider: true },
    { title: "Articles", icon: "receipt", link: "products", divider: false },
    { title: "Stocks", icon: "store", link: "d", divider: false },
    { title: "Ventes", icon: "add_shopping_cart", link: "e", divider: true },
    { title: "Paiements", icon: "account_balance", link: "f", divider: true },
    { title: "Reparations", icon: "build", link: "g", divider: true },
    { title: "Configuration", icon: "settings", link: "h", divider: true }
];