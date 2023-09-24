import { MenuItems } from "src/app/core/models/interfaces";

export const MENU_ITEMS: MenuItems[] = [
    { title: "Utilisateurs", icon: "manage_accounts", link: "users", divider: false },
    { title: "Clients", icon: "people", link: "customer", divider: false },
    { title: "Fournisseurs", icon: "shop", link: "provider", divider: false },
    {
        title: "Articles", icon: "receipt", link: "", divider: false, submenu: [
            { title: "Appareils", icon: "subitem1", link: "products/appareil", divider: false },
            { title: "Pièces", icon: "subitem2", link: "products/piece", divider: false },
            { title: "Accessoirs", icon: "subitem2", link: "products/accessoir", divider: false },
            { title: "Matériels", icon: "subitem2", link: "products/materiel", divider: false },
        ]
    },
    { title: "Stocks", icon: "store", link: "stock", divider: false },
    { title: "Ventes", icon: "add_shopping_cart", link: "sales", divider: true },
    { title: "Paiements", icon: "account_balance", link: "paiement", divider: true },
    { title: "Reparations", icon: "build", link: "repair", divider: true },
    {
        title: "Configuration", icon: "settings", link: "config", divider: false, submenu: [
            { title: "Type Article", icon: '', link: 'config/type_article', divider: false }
        ]
    }
];