
export interface DialogInfo {
  title: string;
  type?: "warn" | "success" | "info" | "danger";
  message: string;
  cancelAction?: string;
  valideAction?: string;
  personaliseDialog:boolean|undefined;
}
