# 🧱 WallLoader - Unity

Este projeto em Unity tem como objetivo carregar dados de paredes a partir de um arquivo JSON e instanciá-las como GameObjects na cena. Ele utiliza o padrão de projeto **Factory** para criar as paredes a partir de prefabs personalizados, mantendo o código organizado, extensível e desacoplado.

## 📁 Estrutura do Projeto

Abaixo está uma explicação detalhada dos principais scripts presentes no projeto:

### `WallLoader.cs`

Componente principal que deve ser atribuído a um GameObject da cena. Ele é responsável por:

* Ler o arquivo `walls.json` dentro da pasta `StreamingAssets`;
* Usar um `IWallDataProvider` para carregar os dados das paredes;
* Criar um objeto vazio "Walls" que agrupará as instâncias na hierarquia;
* Usar uma implementação de `IWallFactory` para instanciar cada parede.

**Este script deve ser adicionado como componente em um GameObject vazio da cena (por exemplo, chamado ********************************************`WallLoader`********************************************). No Inspetor, é necessário preencher os seguintes campos:**

* `Wall Prefab`: o prefab da parede que será instanciado;
* `Down Scale Factor`: fator de escala usado para converter as coordenadas do JSON para a cena (ex: 0.04);
* `Json File Name`: nome do arquivo JSON dentro da pasta `StreamingAssets` (ex: `walls.json`).

> **N**este projeto, foi escolhido utilizar um **cubo padrão do Unity** (`GameObject > 3D Object > Cube`) como prefab.

### `WallData.cs`

Classe que representa os dados de uma única parede. Essa classe é serializável e seus campos correspondem diretamente às propriedades contidas no arquivo JSON:

* `x0`, `y0`, `x1`, `y1`: coordenadas dos pontos inicial e final da parede;
* `width`: largura da parede;
* `height`: altura da parede;
* `orientation`: "horizontal" ou "vertical";
* `class`: categoria ou classe da parede, podendo ser usada para estilização ou filtragem.

### `WallDataList.cs`

Classe auxiliar usada para encapsular uma lista de objetos `WallData` caso seja necessário um formato de JSON que contenha uma lista agrupada (ex: `{ "walls": [ ... ] }`). Não está em uso atualmente, mas é útil para adaptações futuras.

### `IWallDataProvider.cs`

Interface que define o contrato para qualquer classe que forneça dados de parede. Isso permite que a origem dos dados possa ser trocada facilmente (por exemplo, banco de dados, web API, etc), mantendo o código do `WallLoader` desacoplado.

```csharp
interface IWallDataProvider {
    IEnumerable<WallData> LoadWalls();
}
```

### `JsonWallDataProvider.cs`

Implementação de `IWallDataProvider` que lê os dados do arquivo `.json` e converte em uma lista de `WallData`. Usa `JsonUtility.FromJson<WallData[]>` para desserialização.

### `IWallFactory.cs`

Interface que define como uma parede deve ser criada a partir de um `WallData`.

```csharp
interface IWallFactory {
    GameObject CreateWall(WallData data);
}
```

### `PrefabWallFactory.cs`

Implementação concreta de `IWallFactory` que instancia objetos na cena com base em um `GameObject` prefab. Responsável por:

* Calcular a posição central entre `x0/y0` e `x1/y1`;
* Definir a escala do objeto com base na orientação da parede;
* Agrupar todas as instâncias sob um `Transform` pai fornecido no construtor.

## 🔧 Como Usar

1. Clone o repositório no Unity.
2. Abra a cena e arraste um prefab de parede para o campo `wallPrefab` no componente `WallLoader`.
3. Certifique-se de que o arquivo `walls.json` está presente em `Assets/StreamingAssets` com o seguinte conteúdo de exemplo:

```json
[
  {
    "x0": 0,
    "y0": 0,
    "x1": 5,
    "y1": 0,
    "width": 0.1,
    "height": 2.5,
    "orientation": "horizontal",
    "class": "parede_externa"
  }
]
```

4. Rode a cena no Unity e as paredes serão criadas automaticamente.
