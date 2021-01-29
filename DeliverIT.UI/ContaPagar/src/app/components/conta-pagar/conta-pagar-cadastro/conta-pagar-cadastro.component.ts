import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContaPagar } from 'src/app/models/conta-pagar/conta-pagar.model';
import { ContaPagarService } from 'src/app/services/conta-pagar.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-conta-pagar-cadastro',
  templateUrl: './conta-pagar-cadastro.component.html',
  styleUrls: ['./conta-pagar-cadastro.component.css']
})
export class ContaPagarCadastroComponent implements OnInit {

  contaPagar: ContaPagar;
  mensagemErro = '';
  @ViewChild('contaPagarForm', { static: true }) contaPagarForm: FormGroup;
  @ViewChild('inputDataPagamento', { static: true }) dataPagamento: HTMLInputElement;
  @ViewChild('inputDataVencimento', { static: true }) dataVencimento: HTMLInputElement;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private contaPagarService: ContaPagarService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    setTimeout(() => {
      this.contaPagarForm.setValue({
        nome: '',
        dataVencimento: '',
        dataPagamento: '',
        valorOriginal: ''
      });  
    }, (100));
  }


  onSubmit() {

    if (this.contaPagarForm.valid) {

      this.contaPagarService.salvar(this.contaPagarForm.value).subscribe((resp) => {
        this.mensagemErro = '';
        this.snackBar.open('Conta salva com sucesso!', 'OK', {
          duration: 2000,
        });
        setTimeout(() => {
           this.router.navigate(['conta-pagar', 'lista']);
        }, 2000);

      }, (resp) => {
        this.mensagemErro = resp.error;
        console.error(resp.message);
        this.snackBar.open(resp.message, 'OK', {
          duration: 2000
        });

      });
    }
  }
}
