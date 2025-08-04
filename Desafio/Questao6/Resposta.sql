-- CTE: Produtos de limpeza com média de satisfação > 70%
WITH ProdutosBemAvaliados AS (
    SELECT id_produto_limpeza
    FROM Pesquisa_Mercado
    GROUP BY id_produto_limpeza
    HAVING AVG(satisfacao) > 70
)

-- Consulta principal: montar os kits
SELECT DISTINCT
  pl.nome AS nome_produto_limpeza,                          -- Nome do produto de limpeza
  a.nome AS nome_alimento,                                  -- Nome do alimento
  ROUND((ee_pl.preco + ee_a.preco) * 0.85, 2) AS preco_kit, -- Preço com 15% de desconto
  ROUND(((ee_pl.preco + ee_a.preco) * 0.85) - 
         (ee_pl.custo + ee_a.custo), 2) AS lucro_kit,       -- Lucro do kit
  CASE                                                      -- Data de validade do kit (a menor entre os dois)
    WHEN a.data_validade < pl.data_validade THEN a.data_validade
    ELSE pl.data_validade
  END AS data_validade_kit

-- Junções necessárias
FROM Produto_Limpeza pl
JOIN ProdutosBemAvaliados pba ON pba.id_produto_limpeza = pl.id
JOIN Elemento_Estoque ee_pl ON ee_pl.id = pl.id_elemento_estoque
JOIN Alimento a ON a.data_validade <= DATEADD(DAY, 5, GETDATE()) -- alimentos vencendo em até 5 dias
JOIN Elemento_Estoque ee_a ON ee_a.id = a.id_elemento_estoque

-- Ordenar os kits por lucro decrescente
ORDER BY lucro_kit DESC;