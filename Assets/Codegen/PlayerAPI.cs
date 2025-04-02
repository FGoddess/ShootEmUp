/**
* Code generation. Don't modify! 
**/

using UnityEngine;
using Atomic.Entities;
using System.Runtime.CompilerServices;
using Atomic.Elements;

namespace Atomic.Entities
{
    public static class PlayerAPI
    {
        ///Keys
        public const int HitPoints = 0; // ReactiveInt
        public const int Bullets = 1; // ReactiveInt
        public const int Kills = 2; // ReactiveInt
        public const int MaxBullets = 3; // int
        public const int MoveSpeed = 4; // float
        public const int RotationSpeed = 5; // float
        public const int IsShooting = 6; // bool
        public const int IsShootingPressed = 7; // ReactiveBool
        public const int ShootingCooldown = 8; // float
        public const int Root = 9; // Transform
        public const int RootView = 10; // Transform
        public const int InputDir = 11; // Vector2
        public const int LookTarget = 12; // Vector3
        public const int Animator = 13; // Animator
        public const int AnimatorDispatcher = 14; // AnimatorDispatcher
        public const int DamageRequest = 15; // BaseEvent<int>
        public const int DamageVFX = 16; // ParticleSystem
        public const int DamageSFX = 17; // AudioSource


        ///Extensions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetHitPoints(this IEntity obj) => obj.GetValue<ReactiveInt>(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetHitPoints(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(HitPoints, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddHitPoints(this IEntity obj, ReactiveInt value) => obj.AddValue(HitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasHitPoints(this IEntity obj) => obj.HasValue(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelHitPoints(this IEntity obj) => obj.DelValue(HitPoints);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetHitPoints(this IEntity obj, ReactiveInt value) => obj.SetValue(HitPoints, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetBullets(this IEntity obj) => obj.GetValue<ReactiveInt>(Bullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetBullets(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(Bullets, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddBullets(this IEntity obj, ReactiveInt value) => obj.AddValue(Bullets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasBullets(this IEntity obj) => obj.HasValue(Bullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelBullets(this IEntity obj) => obj.DelValue(Bullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetBullets(this IEntity obj, ReactiveInt value) => obj.SetValue(Bullets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveInt GetKills(this IEntity obj) => obj.GetValue<ReactiveInt>(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetKills(this IEntity obj, out ReactiveInt value) => obj.TryGetValue(Kills, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddKills(this IEntity obj, ReactiveInt value) => obj.AddValue(Kills, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasKills(this IEntity obj) => obj.HasValue(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelKills(this IEntity obj) => obj.DelValue(Kills);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetKills(this IEntity obj, ReactiveInt value) => obj.SetValue(Kills, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetMaxBullets(this IEntity obj) => obj.GetValue<int>(MaxBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMaxBullets(this IEntity obj, out int value) => obj.TryGetValue(MaxBullets, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMaxBullets(this IEntity obj, int value) => obj.AddValue(MaxBullets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMaxBullets(this IEntity obj) => obj.HasValue(MaxBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMaxBullets(this IEntity obj) => obj.DelValue(MaxBullets);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMaxBullets(this IEntity obj, int value) => obj.SetValue(MaxBullets, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetMoveSpeed(this IEntity obj) => obj.GetValue<float>(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMoveSpeed(this IEntity obj, out float value) => obj.TryGetValue(MoveSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddMoveSpeed(this IEntity obj, float value) => obj.AddValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetMoveSpeed(this IEntity obj, float value) => obj.SetValue(MoveSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetRotationSpeed(this IEntity obj) => obj.GetValue<float>(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRotationSpeed(this IEntity obj, out float value) => obj.TryGetValue(RotationSpeed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRotationSpeed(this IEntity obj, float value) => obj.AddValue(RotationSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRotationSpeed(this IEntity obj) => obj.HasValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRotationSpeed(this IEntity obj) => obj.DelValue(RotationSpeed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRotationSpeed(this IEntity obj, float value) => obj.SetValue(RotationSpeed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool GetIsShooting(this IEntity obj) => obj.GetValue<bool>(IsShooting);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsShooting(this IEntity obj, out bool value) => obj.TryGetValue(IsShooting, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsShooting(this IEntity obj, bool value) => obj.AddValue(IsShooting, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsShooting(this IEntity obj) => obj.HasValue(IsShooting);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsShooting(this IEntity obj) => obj.DelValue(IsShooting);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsShooting(this IEntity obj, bool value) => obj.SetValue(IsShooting, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReactiveBool GetIsShootingPressed(this IEntity obj) => obj.GetValue<ReactiveBool>(IsShootingPressed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetIsShootingPressed(this IEntity obj, out ReactiveBool value) => obj.TryGetValue(IsShootingPressed, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddIsShootingPressed(this IEntity obj, ReactiveBool value) => obj.AddValue(IsShootingPressed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasIsShootingPressed(this IEntity obj) => obj.HasValue(IsShootingPressed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelIsShootingPressed(this IEntity obj) => obj.DelValue(IsShootingPressed);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetIsShootingPressed(this IEntity obj, ReactiveBool value) => obj.SetValue(IsShootingPressed, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float GetShootingCooldown(this IEntity obj) => obj.GetValue<float>(ShootingCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetShootingCooldown(this IEntity obj, out float value) => obj.TryGetValue(ShootingCooldown, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddShootingCooldown(this IEntity obj, float value) => obj.AddValue(ShootingCooldown, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasShootingCooldown(this IEntity obj) => obj.HasValue(ShootingCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelShootingCooldown(this IEntity obj) => obj.DelValue(ShootingCooldown);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetShootingCooldown(this IEntity obj, float value) => obj.SetValue(ShootingCooldown, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetRoot(this IEntity obj) => obj.GetValue<Transform>(Root);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRoot(this IEntity obj, out Transform value) => obj.TryGetValue(Root, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRoot(this IEntity obj, Transform value) => obj.AddValue(Root, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRoot(this IEntity obj) => obj.HasValue(Root);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRoot(this IEntity obj) => obj.DelValue(Root);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRoot(this IEntity obj, Transform value) => obj.SetValue(Root, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Transform GetRootView(this IEntity obj) => obj.GetValue<Transform>(RootView);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetRootView(this IEntity obj, out Transform value) => obj.TryGetValue(RootView, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddRootView(this IEntity obj, Transform value) => obj.AddValue(RootView, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasRootView(this IEntity obj) => obj.HasValue(RootView);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelRootView(this IEntity obj) => obj.DelValue(RootView);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetRootView(this IEntity obj, Transform value) => obj.SetValue(RootView, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 GetInputDir(this IEntity obj) => obj.GetValue<Vector2>(InputDir);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetInputDir(this IEntity obj, out Vector2 value) => obj.TryGetValue(InputDir, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddInputDir(this IEntity obj, Vector2 value) => obj.AddValue(InputDir, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasInputDir(this IEntity obj) => obj.HasValue(InputDir);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelInputDir(this IEntity obj) => obj.DelValue(InputDir);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetInputDir(this IEntity obj, Vector2 value) => obj.SetValue(InputDir, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 GetLookTarget(this IEntity obj) => obj.GetValue<Vector3>(LookTarget);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetLookTarget(this IEntity obj, out Vector3 value) => obj.TryGetValue(LookTarget, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddLookTarget(this IEntity obj, Vector3 value) => obj.AddValue(LookTarget, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasLookTarget(this IEntity obj) => obj.HasValue(LookTarget);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelLookTarget(this IEntity obj) => obj.DelValue(LookTarget);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetLookTarget(this IEntity obj, Vector3 value) => obj.SetValue(LookTarget, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Animator GetAnimator(this IEntity obj) => obj.GetValue<Animator>(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimator(this IEntity obj, out Animator value) => obj.TryGetValue(Animator, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimator(this IEntity obj, Animator value) => obj.AddValue(Animator, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimator(this IEntity obj) => obj.HasValue(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimator(this IEntity obj) => obj.DelValue(Animator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimator(this IEntity obj, Animator value) => obj.SetValue(Animator, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AnimatorDispatcher GetAnimatorDispatcher(this IEntity obj) => obj.GetValue<AnimatorDispatcher>(AnimatorDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetAnimatorDispatcher(this IEntity obj, out AnimatorDispatcher value) => obj.TryGetValue(AnimatorDispatcher, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddAnimatorDispatcher(this IEntity obj, AnimatorDispatcher value) => obj.AddValue(AnimatorDispatcher, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasAnimatorDispatcher(this IEntity obj) => obj.HasValue(AnimatorDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelAnimatorDispatcher(this IEntity obj) => obj.DelValue(AnimatorDispatcher);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetAnimatorDispatcher(this IEntity obj, AnimatorDispatcher value) => obj.SetValue(AnimatorDispatcher, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static BaseEvent<int> GetDamageRequest(this IEntity obj) => obj.GetValue<BaseEvent<int>>(DamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamageRequest(this IEntity obj, out BaseEvent<int> value) => obj.TryGetValue(DamageRequest, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamageRequest(this IEntity obj, BaseEvent<int> value) => obj.AddValue(DamageRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamageRequest(this IEntity obj) => obj.HasValue(DamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamageRequest(this IEntity obj) => obj.DelValue(DamageRequest);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamageRequest(this IEntity obj, BaseEvent<int> value) => obj.SetValue(DamageRequest, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ParticleSystem GetDamageVFX(this IEntity obj) => obj.GetValue<ParticleSystem>(DamageVFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamageVFX(this IEntity obj, out ParticleSystem value) => obj.TryGetValue(DamageVFX, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamageVFX(this IEntity obj, ParticleSystem value) => obj.AddValue(DamageVFX, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamageVFX(this IEntity obj) => obj.HasValue(DamageVFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamageVFX(this IEntity obj) => obj.DelValue(DamageVFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamageVFX(this IEntity obj, ParticleSystem value) => obj.SetValue(DamageVFX, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AudioSource GetDamageSFX(this IEntity obj) => obj.GetValue<AudioSource>(DamageSFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetDamageSFX(this IEntity obj, out AudioSource value) => obj.TryGetValue(DamageSFX, out value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AddDamageSFX(this IEntity obj, AudioSource value) => obj.AddValue(DamageSFX, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasDamageSFX(this IEntity obj) => obj.HasValue(DamageSFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DelDamageSFX(this IEntity obj) => obj.DelValue(DamageSFX);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetDamageSFX(this IEntity obj, AudioSource value) => obj.SetValue(DamageSFX, value);
    }
}
