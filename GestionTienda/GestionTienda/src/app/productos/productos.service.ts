import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject, of, Subject } from 'rxjs';
import { IProductos } from './productos';
import { IProcess } from '../process/process';
import { map, switchMap, debounceTime, tap } from 'rxjs/operators';
import { SortColumn } from '../directives/sort.directive';
import { SortDirection } from '../schedule/sort-schedule.directive';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    //this.fillModules();
    this._search$.pipe(
        switchMap(() => this._search())
      ).subscribe(result => {
        this._productos$.next(result.productos);
        //this._total$.next(result.total);
      });
     //this._search$.next();
  }
  private apiUrl = this.baseUrl + "api/getallproductos";
  private _productos$ = new BehaviorSubject<IProductos[]>([]);
  private PRODUCTOS = [];
  public _search$ = new Subject<void>();
  private _total$ = new BehaviorSubject<number>(0);
  public _processId$ = new BehaviorSubject<number>(0);
  private _state: State = {
    page: 1,
    pageSize: 6,
    searchTerm: '',
    sortColumn: 'idProceso',
    sortDirection: 'asc'
  };
  fillProductos() {
    this.getProductos().toPromise().then(productos => { this.PRODUCTOS = productos; this._productos$.next(productos); this._search$.next(); });
  }
  /*getModule(id: number): Observable<IProductos> {
    return this.http.get<IProductos>(this.apiUrl +"/"+ id);
  }
  createModule(module: IProductos): Observable<IProductos> {
    return this.http.post<IProductos>(this.apiUrl, module);
  }
  updateModule(module: IProductos): Observable<IProductos> {
    return this.http.put<IProductos>(this.apiUrl, module);
  }
  deleteModule(module: IProductos): Observable<IProductos> {
    return this.http.put<IProductos>(this.apiUrl + "/delete", module);
  }
  getModuleByProcess(idProceso:string): Observable<IProductos[]>{
      return this.http.get<IProductos[]>(this.apiUrl+"/getmodulebyprocess/"+idProceso);
  }*/
 
  getProcesses(): Observable<IProcess[]> {
    return this.http.get<IProcess[]>(this.apiUrl + "/getprocesses")
      .pipe(map(data => data));
  }
  getNextModuleCode(processId: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + "/getNextModuleCode/" + processId);
  }

  getProductos(): Observable<IProductos[]> {
    return this.http.get<IProductos[]>(this.apiUrl +"/productos");
  }

  get productos$() { return this._productos$.asObservable(); }
  get total$() { return this._total$.asObservable(); }
  get page() { return this._state.page; }
  get pageSize() { return this._state.pageSize; }
  get searchTerm() { return this._state.searchTerm; }

  set page(page: number) { this._set({ page }); }
  set pageSize(pageSize: number) { this._set({ pageSize }); }
  set searchTerm(searchTerm: string) { this._set({ searchTerm }); }
  set sortColumn(sortColumn: SortColumn) { this._set({ sortColumn }); }
  set sortDirection(sortDirection: SortDirection) { this._set({ sortDirection }); }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const { sortColumn, sortDirection, pageSize, page, searchTerm } = this._state;

    let productos = sort(this.PRODUCTOS, sortColumn, sortDirection);
    if (this._processId$.getValue() == 0) {
      productos = productos.filter(module => matches(module, searchTerm));
    } else {
      productos = productos.filter(module => module.idProceso == this._processId$.getValue());
      productos = productos.filter(module => matches(module, searchTerm));
    }
    const total = productos.length;
    productos = productos.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ productos, total });
  }
}


interface SearchResult {
  productos: IProductos[];
  total: number;
}

interface State {
  page: number;
  pageSize: number;
  searchTerm: string;
  sortColumn: SortColumn;
  sortDirection: SortDirection;
}

const compare = (v1: string, v2: string) => v1 < v2 ? -1 : v1 > v2 ? 1 : 0;

function sort(modules: IProductos[], column: SortColumn, direction: string): IProductos[] {
  if (direction === '' || column === '') {
    return modules;
  } else {
    return [...modules].sort((a, b) => {
      const res = compare(`${a[column]}`, `${b[column]}`);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(module: IProductos, term: string) {
  return module.descripcion.toLowerCase().includes(term.toLowerCase()) || module.textoModulo.includes(term) || module.codigo.toLowerCase().includes(term.toLowerCase());
}



