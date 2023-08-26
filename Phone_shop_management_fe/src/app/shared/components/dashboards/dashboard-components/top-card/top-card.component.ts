import { Component } from '@angular/core';
// import { DatabaseService } from 'src/app/services/database.service';

@Component({
  selector: 'app-top-card',
  templateUrl: './top-card.component.html',
  styleUrls: ['./top-card.component.scss'],
})
export class TopCardComponent {
  nbcustomer=0;
  product = 0;
  achat = 0;
  constructor(
    // private dbService:DatabaseService
  ) {
    this.getNumberCustomer();
  }

  async getNumberCustomer(){
    // this.nbcustomer = (await this.dbService.db.customer.find().exec()).length;
    // this.product = (await this.dbService.db.product.find().exec()).length;
    // this.achat = (await this.dbService.db.commandcustomer.find().exec()).length
  }
}
