import { Component, OnInit, ViewChild } from '@angular/core';
import { ContaPagar } from 'src/app/models/conta-pagar/conta-pagar.model';
import { ContaPagarService } from 'src/app/services/conta-pagar.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-conta-pagar-lista',
  templateUrl: './conta-pagar-lista.component.html',
  styleUrls: ['./conta-pagar-lista.component.css']
})
export class ContaPagarListaComponent implements OnInit {

  loading: boolean = false;
  contas: ContaPagar[];
  displayedColumns: string[] = ['Nome', 'Valor Original', 'Data de Vencimento', 'Data de Pagamento', 'Valor Corrigido'];
  dataSource: MatTableDataSource<ContaPagar>;
  @ViewChild(MatPaginator, {static: true }) paginator: MatPaginator;
  
  constructor(private contaPagarService: ContaPagarService) {}

  ngAfterViewInit() {
    
  }

  ngOnInit() {
    this.loading = true;   
    this.contaPagarService.listar().subscribe((resp) => {
      this.loading = false;
      this.contas = resp;
      this.dataSource = new MatTableDataSource(this.contas);
      this.dataSource.paginator = this.paginator;
    }, (error) => {
      this.loading = false;
      console.error(error.message);
    });
  }

}
