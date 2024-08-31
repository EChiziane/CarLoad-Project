const express = require('express');
const fs = require('fs');
const cors = require('cors');
const path = require('path');

const app = express();
const PORT = 3000;
const DIRECTORY_PATH = path.join(__dirname, 'src');
const FILE_PATH = path.join(DIRECTORY_PATH, 'informacao.txt');

app.use(cors());
app.use(express.json());

// Cria o diretório 'src' se não existir
if (!fs.existsSync(DIRECTORY_PATH)) {
  fs.mkdirSync(DIRECTORY_PATH, { recursive: true });
}

// Cria o ficheiro 'informacao.txt' se não existir
if (!fs.existsSync(FILE_PATH)) {
  fs.writeFileSync(FILE_PATH, '', 'utf8');
}

// Endpoint para ler dados do ficheiro
app.get('/api/informacao', (req, res) => {
  if (fs.existsSync(FILE_PATH)) {
    fs.readFile(FILE_PATH, 'utf8', (err, data) => {
      if (err) {
        console.error('Erro ao ler o ficheiro:', err);
        return res.status(500).send('Erro ao ler o ficheiro.');
      }

      // Converte o conteúdo do ficheiro para um array JSON
      const informacoes = data.split('\n').filter(line => line.trim() !== '').map(line => {
        const [data, descricao] = line.split(': ');
        return { data: data.trim(), descricao: descricao.trim() };
      });

      // Envia a resposta como JSON
      res.json(informacoes);
    });
  } else {
    res.json([]); // Retorna uma lista vazia se o ficheiro não existir
  }
});

// Endpoint para adicionar nova informação ao ficheiro
app.post('/api/informacao', (req, res) => {
  const { data, descricao } = req.body;
  console.log(req.body)


  let fileData = [];
  if (fs.existsSync(FILE_PATH)) {
    const existingData = fs.readFileSync(FILE_PATH, 'utf-8');
    try {
      fileData = existingData.trim() === '' ? [] : JSON.parse(existingData);
    } catch (err) {
      return res.status(500).json({ error: 'Erro ao processar JSON.' });
    }
  }

  const newInfo = req.body;
  fileData.push(newInfo);
  fs.writeFileSync(FILE_PATH, JSON.stringify(fileData, null, 2));

  // Retorna o novo dado gravado
  res.status(200).json(newInfo);
});

app.listen(PORT, () => {
  console.log(`Servidor rodando na porta ${PORT}`);
});
