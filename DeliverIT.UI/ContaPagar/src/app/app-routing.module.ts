import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContaPagarCadastroComponent } from './components/conta-pagar/conta-pagar-cadastro/conta-pagar-cadastro.component';
import { ContaPagarListaComponent } from './components/conta-pagar/conta-pagar-lista/conta-pagar-lista.component';
import { ContaPagarComponent } from './components/conta-pagar/conta-pagar.component';
import { SobreComponent } from './components/sobre/sobre.component';


const routes: Routes = [
  { path: 'conta-pagar', component: ContaPagarComponent, 
     children: [
        { path: 'lista', component: ContaPagarListaComponent }, 
        { path: 'cadastro', component: ContaPagarCadastroComponent }
     ]  
  },
  { path: 'sobre', component: SobreComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
