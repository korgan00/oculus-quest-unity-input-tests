using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllerSensitiveButtonInput : IControllerButtonInput {
    
    float buttonPreassure { get; }
}
