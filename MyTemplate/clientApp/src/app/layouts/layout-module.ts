
import { NgModule } from '@angular/core';
import { SharedModule } from 'primeng/api';

import { SiteLayoutComponent } from './site-layout/site-layout.component';

@NgModule({
  declarations: [
    SiteLayoutComponent
  ],
  imports: [
    SharedModule
  ],
})
export class LayoutModule { }
