from pandas import read_csv
from sys import argv

file = argv[1]
field = argv[2]
output = argv[3]

data = read_csv(file)
data[field] = [record.capitalize() for record in data[field]]
data.to_csv(f"{output}.csv", index=False)
