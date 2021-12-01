import { NgModule } from '@angular/core';
import { SharedModule } from '@app/core';

import { HomeRoutingModule } from './home-routing.module';

@NgModule({
  declarations: [],
  imports: [
    HomeRoutingModule,
	  SharedModule
	]
})
export class HomeModule { }
