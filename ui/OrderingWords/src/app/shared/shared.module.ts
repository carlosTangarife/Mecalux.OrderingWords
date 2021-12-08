import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpService } from '@shared/services/http.service';

const SHARED_MODULES = [CommonModule, FormsModule, ReactiveFormsModule];

@NgModule({
  imports: [SHARED_MODULES],
  exports: [SHARED_MODULES],
  providers: [HttpService]
})
export class SharedModule { }
