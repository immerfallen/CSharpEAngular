import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  public widthImg: number = 150;
  public marginImg: number = 2;
  public showImage: boolean = true;
  private _filterString: string = "";

  constructor(private http: HttpClient) { }

  public get filterString(): string {
    return this._filterString;
  }

  public set filterString(value: string) {
    this._filterString = value;
    this.eventosFiltrados = this.filterString ? this.filtrarEventos(this.filterString) : this.eventos;
  }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/evento').subscribe(
      response => { this.eventos = response; this.eventosFiltrados = response },
      error => console.log(error)
    );
  }

  public handleClickShowImage() {
    this.showImage = !this.showImage
  }

  public filtrarEventos(filterString: string): any {
    filterString = filterString.toLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLowerCase().indexOf(filterString) !== -1
        || evento.local.toLowerCase().indexOf(filterString) !== -1
    )
  }

}
