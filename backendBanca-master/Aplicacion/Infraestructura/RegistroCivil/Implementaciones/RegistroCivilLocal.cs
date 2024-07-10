﻿using Aplicacion.Infraestructura.RegistroCivil.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Infraestructura.RegistroCivil.Implementaciones
{
    public class RegistroCivilLocal : IRegistroCivil
    {
        public async Task<bool> ValidarDatosCedula(string cedula, string codigoDactilar)
        {
            return ValidarCedula(cedula) && ValidarCodigoDactilar(codigoDactilar);
        }

        private bool ValidarCedula(string cedula)
        {
            if (!SoloNumeros(cedula))
            {
                return false;
            }

            if (cedula.Length != 10 && cedula.Length != 13)
            {
                return false;
            }

            List<int> digitos = new();
            for (int i = 0; i < cedula.Length; i++)
            {
                digitos.Add(int.Parse(cedula[i].ToString()));
            }
            List<int> posicionesImpares = new List<int>();
            List<int> posicionesPares = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                {
                    if ((digitos[i] * 2) > 9)
                    {
                        posicionesImpares.Add((digitos[i] * 2) - 9);
                    }
                    else
                    {
                        posicionesImpares.Add(digitos[i] * 2);
                    }

                }
                else
                {
                    posicionesPares.Add(digitos[i]);
                }
            }

            int suma = posicionesPares.Sum() + posicionesImpares.Sum();
            int modulo = suma % 10;
            int digitoVerificador = 0;
            if (modulo > 0)
            {
                digitoVerificador = 10 - modulo;
            }

            if (digitos[9] != digitoVerificador)
            {
                return false;
            }

            if (cedula.Length == 13)
            {
                if (digitos[10] != 0 || digitos[11] != 0 || digitos[12] != 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidarCodigoDactilar(string codigoDactilar)
        {
            if (codigoDactilar.IsNullOrEmpty()) return false;
            if (codigoDactilar.Length != 10) return false;
            return true;
        }

        private bool SoloNumeros(string cadena)
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if (!char.IsNumber(cadena[i]))
                {
                    return false;
                }
            }
            return true;
        }
        // Aqui metodo para validacion de rostro
    }
}
