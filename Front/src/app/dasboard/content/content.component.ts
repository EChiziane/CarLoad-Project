import { Component } from '@angular/core';
import { Chart, registerables } from 'chart.js';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent {
  ngAfterViewInit() {
    Chart.register(...registerables); // Registra todos os componentes necessários do Chart.js

    const ctx = (document.getElementById('salesChart') as HTMLCanvasElement).getContext('2d');

    if (ctx) {
      new Chart(ctx, {
        type: 'bar',
        data: {
          labels: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho'],
          datasets: [{
            label: 'Vendas',
            data: [30, 40, 35, 50, 60, 70],
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
          }]
        },
        options: {
          responsive: true,
          plugins: {
            legend: {
              display: true
            },
            tooltip: {
              callbacks: {
                label: function(tooltipItem) {
                  return `Vendas: ${tooltipItem.raw}`;
                }
              }
            }
          },
          scales: {
            x: {
              beginAtZero: true
            },
            y: {
              beginAtZero: true
            }
          }
        }
      });
    }
  }

  printTable() {
    const originalContent = document.body.innerHTML; // Salva o conteúdo original da página
    const tableContent = document.getElementById('productTable')?.outerHTML;
    if (tableContent) {
      const printWindow = window.open('', '', 'height=600,width=800');
      if (printWindow) {
        printWindow.document.write('<html><head><title>Imprimir Tabela</title>');
        printWindow.document.write('<style>table { width: 100%; border-collapse: collapse; } th, td { border: 1px solid #ddd; padding: 8px; text-align: center; } th { background-color: #f8f9fa; } .actions, th:nth-child(6), td:nth-child(6) { display: none; } </style>'); // Inclui a regra CSS para impressão
        printWindow.document.write('</head><body>');
        printWindow.document.write(tableContent);
        printWindow.document.write('</body></html>');
        printWindow.document.close(); // Fecha o documento
        printWindow.focus(); // Foca na nova janela
        printWindow.print(); // Imprime o conteúdo
        printWindow.onafterprint = () => printWindow.close(); // Fecha a janela após a impressão
      }
    }
  }
}
