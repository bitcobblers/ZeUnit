import { component$ } from "@builder.io/qwik";
import { Link } from "@builder.io/qwik-city";
import GitHubIcon from "./git-hub-icon";
import { Logo, Logomark } from "./logo";
import MobileNavigation from "./mobile-navigation";
export default component$(() => {
//   let [isScrolled, setIsScrolled] = useState(false)

//   useEffect$(() => {
//     function onScroll() {
//       setIsScrolled(window.scrollY > 0)
//     }
//     onScroll()
//     window.addEventListener('scroll', onScroll, { passive: true })
//     return () => {
//       window.removeEventListener('scroll', onScroll)
//     }
//   }, [])

  return (
    <header
      class="sticky top-0 z-50 flex flex-none flex-wrap items-center justify-between bg-white px-4 py-5 shadow-md shadow-slate-900/5 transition duration-500 sm:px-6 lg:px-8 dark:shadow-none dark:bg-transparent">
      <div class="mr-6 flex lg:hidden">
        <MobileNavigation />
      </div>
      <div class="relative flex flex-grow basis-0 items-center">
        <Link href="/" aria-label="Home page">
          <Logomark class="h-9 w-9 lg:hidden" />          
          <Logo class="hidden h-9 w-auto fill-slate-700 lg:block dark:fill-sky-100 text-2xl" />
        </Link>
      </div>
      <div class="-my-5 mr-6 sm:mr-8 md:mr-0">
        {/* <Search /> */}
      </div>
      <div class="relative flex basis-0 justify-end gap-6 sm:gap-8 md:flex-grow">
        {/* <ThemeSelector class="relative z-10" /> */}
        <Link href="https://github.com/bitcobblers/ZeUnit" target="_blank" class="group" aria-label="ZeUnit repository on GitHub">
          <GitHubIcon class="h-6 w-6 fill-slate-400 group-hover:fill-slate-500 dark:group-hover:fill-slate-300" />
        </Link>
      </div>
    </header>
  )
});