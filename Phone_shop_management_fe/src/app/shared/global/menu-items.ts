import { MenuItems } from "src/app/core/models/interfaces";

export const MENU_ITEMS: MenuItems[] = [
    { title: "Utilisateurs", icon: "manage_accounts", link: "users", divider: false },
    { title: "Clients", icon: "people", link: "customer", divider: false },
    { title: "Fournisseurs", icon: "shop", link: "provider", divider: true },
    { title: "Articles", icon: "receipt", link: "products", divider: false },
    { title: "Stocks", icon: "store", link: "stock", divider: false },
    { title: "Ventes", icon: "add_shopping_cart", link: "sales", divider: true },
    { title: "Paiements", icon: "account_balance", link: "paiement", divider: true },
    { title: "Reparations", icon: "build", link: "repair", divider: true },
    { title: "Configuration", icon: "settings", link: "config", divider: true }
];