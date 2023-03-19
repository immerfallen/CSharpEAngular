import { EventoService } from './../services/evento.service';

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

  constructor(private eventoService: EventoService) { }

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
    this.eventoService.getEvento().subscribe(
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
