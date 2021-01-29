import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MatNativeDateModule, MatInputModule } from '@angular/material';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ContaPagarComponent } from './components/conta-pagar/conta-pagar.component';
import { ContaPagarListaComponent } from './components/conta-pagar/conta-pagar-lista/conta-pagar-lista.component';
import { ContaPagarCadastroComponent } from './components/conta-pagar/conta-pagar-cadastro/conta-pagar-cadastro.component';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { SobreComponent } from './components/sobre/sobre.component';
import { CustomHttpInterceptor } from './services/interceptors/CustomHttpInterceptor.service';
import { registerLocaleData } from '@angular/common';
import localePT from '@angular/common/locales/pt';
import localeExtraPT  from '@angular/common/locales/extra/pt';

registerLocaleData(localePT, 'pt', localeExtraPT);

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ContaPagarComponent,
    ContaPagarListaComponent,
    ContaPagarCadastroComponent,
    SobreComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatCardModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatSnackBarModule,
    MatTableModule,
    MatPaginatorModule,
    MatTooltipModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'pt' },
    { provide: LOCALE_ID, useValue: 'pt' }, 
    { provide: HTTP_INTERCEPTORS, useClass: CustomHttpInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
