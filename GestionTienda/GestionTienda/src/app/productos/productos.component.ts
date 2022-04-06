import { Component, OnInit, ViewChildren, QueryList, DoCheck} from '@angular/core';
import { ProductosService } from './productos.service';
import { AccountService } from '../account/account.service';
import { ToastrService } from 'ngx-toastr';
import { IProductos } from './productos';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { faSort } from '@fortawesome/free-solid-svg-icons';
import { Observable } from 'rxjs';
import { SortEvent, SortDirective } from '../directives/sort.directive';
import { IProcess } from '../process/process';
import { ModalService } from '../modals/modal/modal.service';

@UntilDestroy()
@Component({
      selector: 'app-module',
      templateUrl: './productos.component.html',
      styleUrls: ['./productos.component.css']
    })
export class ProductosComponent implements OnInit , DoCheck {
  public productos: IProductos[];
  public processes: IProcess[];
  productos$: Observable<IProductos[]>;
  total$: Observable<number>;
  faSort = faSort;
  @ViewChildren(SortDirective) headers: QueryList<SortDirective>;
  constructor(public productosService: ProductosService, private accountService: AccountService, private toast: ToastrService, private modalService: ModalService) {
    this.productosService.fillProductos();
    this.productosService._search$.next();
    this.productos$ = productosService.productos$;
    this.total$ = productosService.total$;
    this.productosService.getProcesses().toPromise().then(processes => {
      this.processes = processes;
    });
  }

  ngOnInit() {
    this.productos$.subscribe(productos => this.productos = productos);
    this.loadData();
    //this.accountService.showSubMenu("configuracionMenu"); //DESPLEGAR MENU CONFIGURACION AL INICIAR
  }
  
  loadData(): void {
    this.productosService.getProductos()
      .toPromise().then(productos => this.productos = productos);
  }

  ngDoCheck() {
    if (this.productosService._processId$.value != 0) {
      let processSelect = (<HTMLSelectElement>document.getElementById('idProceso'));
      processSelect.value = this.productosService._processId$.getValue().toString();
    }
  }
  /* delete(module: IModule) {
    let data = {
      title: 'Confirmación de eliminación',
      message: `¿Está seguro que desea eliminar el módulo ${module.textoModulo} del proceso ${(module.process as IProcess).descripcion.toLowerCase()}?`,
      btnText: 'Sí',
      btnCancelText: 'No',
      hasCancelOption: 'Si',
      okBtnClass: 'btn-danger'
    }
    this.modalService.open(data).pipe(
      untilDestroyed(this)
    ).subscribe(result => {
      if (result == "ok click") {
        module.usuarioEliminacion = this.accountService.getLoggedInUser();
        this.moduleService.deleteModule(module).pipe(untilDestroyed(this)).subscribe(null, error => console.error(error), () => { this.moduleService.fillModules(); this.toast.success("Módulo Eliminado!"); });
      }
    });
    
  }
  onSort({ column, direction }: SortEvent) {
    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.moduleService.sortColumn = column;
    this.moduleService.sortDirection = direction;
  }
  processChange() {
    let processSelect = (<HTMLSelectElement>document.getElementById('idProceso'));
    let processId: string = "";
    processId = processSelect.value;
    if (!processId) {
      processId = "0";
    }
    this.moduleService._processId$.next(parseInt(processId));
    this.moduleService._search$.next();
  }*/
}
