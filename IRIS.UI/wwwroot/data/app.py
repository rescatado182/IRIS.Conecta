# convierte countries2.json en la estrucuta
# {
#     public static class Countries
#     {
#         public static List<CountryVM> GetCountries()
#         {
#             return new List<CountryVM>
#         {
#             new CountryVM
#             {
#                 Id = 11,
#                 Name = "Argentina",
#                 States = new List<StateVM>
#                 {
#                     new StateVM
#                     {
#                         Id = 1,
#                         Name = "Buenos Aires",
#                         Cities = new List<CityVM>
#                         {
#                             new CityVM
#                             {
#                                 Id = 1,
#                                 Name = "Balvanera",
#                             }, ...

##ordenar caracteres de tilde Departamento de Andalgal�"

# import json

import json
import os

def get_countries():
    #adicionat utf-8 para evitar error de caracteres no
    with open('countries3.json') as f:    
        data = json.load(f)

    countries = []
    for country in data['countries']:
        country_name = country['name']
        country_id = country['id']
        states = []
        for state in country['states']:
            state_name = state['name']
            state_id = state['id']
            cities = []
            for city in state['cities']:
                cities.append(f"new CityVM {{ Id = {city['id']}, Name = \"{city['name']}\", StateId = {city['state_id']}  }}") 
            states.append(f"new StateVM {{ Id = {state_id}, Name = \"{state_name}\", CountryId = {country_id}, Cities = new List<CityVM> {{ {', '.join(cities)} }} }}")            
        countries.append(f"new CountryVM {{ Id = {country_id}, Name = \"{country_name}\", States = new List<StateVM> {{ {', '.join(states)} }} }}")
    return countries

def main():
    countries = get_countries()
    ## guardar con utf-8
    with open('countries6.cs', 'w', encoding='utf-8') as f:
        f.write("public static class Countries\n{\n")
        f.write("\tpublic static List<CountryVM> GetCountries()\n\t{\n")
        f.write("\t\treturn new List<CountryVM>\n\t\t{\n")
        for country in countries:
            f.write(f"\t\t\t{country},\n")
        f.write("\t\t};\n")
        f.write("\t}\n")
        f.write("};")
    print("countries2.cs created")

if __name__ == "__main__":
    main()









