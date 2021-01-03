# Databricks notebook source
# MAGIC %scala
# MAGIC val containerName = "armazenamento"
# MAGIC val storageAccountName = "dadosguilherme"
# MAGIC val sas = "?sv=2019-12-12&ss=b&srt=sco&sp=rwdlacx&se=2021-01-04T08:41:20Z&st=2021-01-03T15:41:20Z&spr=https&sig=LJgbtKpNQfKXW08mRcDkr2OFOAAf9itrR7SBvuQia8g%3D"
# MAGIC val url = "wasbs://" + containerName + "@" + storageAccountName + ".blob.core.windows.net/"
# MAGIC var config = "fs.azure.sas." + containerName + "." + storageAccountName + ".blob.core.windows.net"

# COMMAND ----------

# MAGIC %scala
# MAGIC dbutils.fs.mount(
# MAGIC   source = url,
# MAGIC   mountPoint = "/mnt/staging",
# MAGIC   extraConfigs = Map(config -> sas))

# COMMAND ----------


# File location and type
file_location = "/mnt/staging/titanic.csv"
file_type = "csv"

# CSV options
infer_schema = "true"
first_row_is_header = "true"
delimiter = ","

# The applied options are for CSV files. For other file types, these will be ignored.
df = spark.read.format(file_type) \
  .option("inferSchema", infer_schema) \
  .option("header", first_row_is_header) \
  .option("sep", delimiter) \
  .load(file_location)

display(df)

# COMMAND ----------

permanent = "titanic"
df.write.format("parquet").saveAsTable(permanent)

# COMMAND ----------

display(df)

# COMMAND ----------

#Selecionar somente as colunas que interessam
colunas_especificas = df.select("PassengerID","Name", "Sex", "Age")
display(colunas_especificas)

# COMMAND ----------

print('Contagem de linhas: ', colunas_especificas.count())

# COMMAND ----------

#Importando bibliotecas 
from pyspark.sql.functions import lit, when, col, regexp_extract

# COMMAND ----------

#Criar uma coluna de aprovados
passageiros = colunas_especificas.withColumn('Aprovados', lit('Sim'))
#passageiros_del = passageiros.drop('Aprovados')
display(passageiros)

# COMMAND ----------


colunas = passageiros.groupBy("Age").count().show(4)


# COMMAND ----------

#Selecionando os passageiros Misters Homens e com idades entre 35 a 45 anos e aprovados

#A função sql em uma SparkSession permite que os aplicativos executem consultas SQL programaticamente e retorna o resultado como um DataFrame.
passageiros.createOrReplaceTempView("pessoas")
sqlDF = spark.sql("SELECT * FROM pessoas where Sex == 'male' and Age between 35 and 45 and Name like '%Mr%'")
sqlDF.show()

# COMMAND ----------

# MAGIC %scala
# MAGIC val aggregate = spark.sql("""
# MAGIC SELECT * FROM pessoas where Sex == 'male' and Age between 35 and 45 and Name like '%Mr%'
# MAGIC """)

# COMMAND ----------

# MAGIC %scala
# MAGIC aggregate.write.mode("overwrite").csv("/mnt/staging/output/aggregate.csv")

# COMMAND ----------

