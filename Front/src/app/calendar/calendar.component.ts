import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

class Informacao {
  constructor(public descricao: string) {}
}

class Dia {
  constructor(public id: string, public data: string, public informacao: Informacao) {}
}

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {
  model: NgbDate | null = null;
  markedDays: Dia[] = [];
  displayedDays: Dia[] = [];
  showInput: boolean = false;
  showInfo: boolean = false;
  info: string = '';
  message: string = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadDataFromFile();  // Carregar dados do ficheiro ao iniciar
  }

  onDateSelect(date: NgbDate) {
    this.model = date;
    this.filterDaysBySelectedDate();
  }

  generateId(): string {
    return `id-${Date.now()}`;
  }

  toggleInput() {
    this.showInput = !this.showInput;
    this.showInfo = false;
  }

  toggleView() {
    this.showInfo = !this.showInfo;
    this.showInput = false;
  }

  saveInfo() {
    if (this.model) {
      const dateStr = `${this.model.year}-${this.model.month}-${this.model.day}`;
      this.http.post('http://localhost:3000/api/informacao', { data: dateStr, descricao: this.info })
        .subscribe(
          () => {
            // Limpa o campo de entrada e atualiza a tabela com a nova informação
            this.info = '';
            alert('Informação salva com sucesso!');
            this.loadDataFromFile();  // Recarrega os dados do backend
          },
          error => {
            console.error('Erro ao salvar informação:', error);
            alert('Erro ao salvar informação. Verifique o console para mais detalhes.');
          }
        );
    }
  }

  filterDaysBySelectedDate() {
    if (this.model) {
      const selectedDateStr = `${this.model.year}-${this.model.month}-${this.model.day}`;
      this.displayedDays = this.markedDays.filter(dia => dia.data === selectedDateStr);

      // Atualiza a mensagem se não houver informações para o dia selecionado
      if (this.displayedDays.length === 0) {
        this.message = 'Não há nenhuma informação para este dia.';
      } else {
        this.message = '';  // Limpa a mensagem se houver informações
      }
    } else {
      this.displayedDays = [...this.markedDays];
      this.message = '';  // Limpa a mensagem se não houver data selecionada
    }
  }

  loadDataFromFile() {
    this.http.get<any[]>('http://localhost:3000/api/informacao').subscribe(data => {
      this.markedDays = data.map(item => new Dia(this.generateId(), item.data, new Informacao(item.descricao)));
      this.displayedDays = [...this.markedDays];
    });
  }
}
