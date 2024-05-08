import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoadingService } from './services/loading-service/loading-service.service';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { SpinnerComponent } from './spinner/spinner.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MaterialButtonComponent } from './reusable-component/material-button/material-button.component';
import { AuthModule } from '@auth0/auth0-angular';
import { environment } from '../environments/environment.development';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SpinnerComponent,
    // MaterialButtonComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    MatDialogModule,
    MatButtonModule,
    AuthModule.forRoot(environment.auth),
  ],
  providers: [
    LoadingService,
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
